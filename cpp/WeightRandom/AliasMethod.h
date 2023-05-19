#pragma once

#include <cassert>
#include <cmath>
#include <iostream>
#include <random>
#include <algorithm>
#include <limits>
#include <functional>
#include <map>
#include <vector>
#include <queue>

/**
 * Walker 的 别名方法(Alias Method)是一个复杂度为 O(1) 的算法，用于在给定加权分布的情况下从数组中选择元素。
 */
template<typename T>
class alias_method_random_generator
{
private:
	typedef std::vector<std::pair<double, size_t>> alias_table_t;
	typedef std::vector<T> value_table_t;
	typedef const std::vector<double> probability_table_t;

public:
	alias_method_random_generator(const value_table_t& vals, const probability_table_t& probs)
		: _values(vals), _alias(generate_alias_table(probs)), _int_dis(0, probs.size() - 1)
	{
		assert(vals.size() == probs.size());
		const double sum = std::accumulate(probs.begin(), probs.end(), 0.0);
		assert(std::fabs(1.0 - sum) < std::numeric_limits<double>::epsilon());
	}

public:
	T operator()() const
	{
		return generate();
	}

	T generate() const
	{
		const size_t idx = _int_dis(_gen);
		if (_real_dis(_gen) >= _alias[idx].first and
			_alias[idx].second != std::numeric_limits<size_t>::max())
		{
			return _values[_alias[idx].second];
		}
		else
		{
			return _values[idx];
		}
	}

private:
	/// 生成别名表
	alias_table_t generate_alias_table(const probability_table_t& probs)
	{
		const size_t sz = probs.size();
		alias_table_t alias(sz, { 0.0, std::numeric_limits<size_t>::max() });
		std::queue<size_t> small, large;

		for (size_t i = 0; i != sz; ++i)
		{
			alias[i].first = (double)sz * probs[i];
			if (alias[i].first < 1.0)
			{
				small.push(i);
			}
			else
			{
				large.push(i);
			}
		}

		while (not(small.empty()) and not(large.empty()))
		{
			auto s = small.front(), l = large.front();
			small.pop(), large.pop();
			alias[s].second = l;
			alias[l].first -= (1.0 - alias[s].first);

			if (alias[l].first < 1.0)
			{
				small.push(l);
			}
			else
			{
				large.push(l);
			}
		}

		return alias;
	}

private:
	const value_table_t _values;
	const alias_table_t _alias;

	mutable std::random_device _rd;
	mutable std::mt19937 _gen{ _rd() };
	mutable std::uniform_real_distribution<double> _real_dis{ 0.0, 1.0 };
	mutable std::uniform_int_distribution<size_t> _int_dis;
};
