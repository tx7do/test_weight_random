-- 跳房子
local function prepare_hopscotch_selection(values, weights)
    assert(#values == #weights)
    local tinsert = table.insert
    local ipairs = ipairs

    local sorted_indices = {} -- 排序的权重索引
    for i, _ in ipairs(weights) do
        tinsert(sorted_indices, i)
    end
    table.sort(
        sorted_indices,
        function(a, b)
            return weights[a] > weights[b]
        end
    )

    local sorted_weights = {} -- 排序的权重列表
    for _, i in ipairs(sorted_indices) do
        tinsert(sorted_weights, weights[i])
    end

    local totals = {} -- 总和列表
    local sum = 0
    for i, w in ipairs(sorted_weights) do
        sum = sum + w
        totals[i] = sum
    end

    -- 返回选择器函数
    return function()
        local n = math.random() * sum
        local idx = 1
        local distance, weight, sidx
        while true do
            if totals[idx] > n then -- 找到
                sidx = sorted_indices[idx]
                return values[sidx], weights[sidx]
            end
            weight = sorted_weights[idx]
            distance = n - totals[idx]
            idx = idx + (1 + distance // weight)
        end
    end
end
