//
// Created by YLB on 2023/5/18.
//

#include "../WeightRandom/AliasMethod.h"

void test_alias_method_random_generator()
{
	std::vector<int> values{ 1, 2, 3, 4 };
	std::vector<double> probs{ 0.05, 0.25, 0.35, 0.35 };

	alias_method_random_generator<int> generator{ values, probs };

	std::map<int, size_t> counter;

	for (size_t i = 0; i != 400000; ++i)
	{
		int x = generator();
		assert(std::find(values.begin(), values.end(), x) != values.end());
		++counter[x];
	}
	for (auto pair : counter)
	{
		std::cout << pair.first << "[" << pair.second << "]" << ": \t";
		for (size_t i = 0; i != pair.second / 2500; ++i)
		{
			std::cout << '=';
		}
		std::cout << std::endl;
	}
}

int main()
{
	test_alias_method_random_generator();
	return 0;
}
