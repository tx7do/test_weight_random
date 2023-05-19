-- 二叉查找
local function prepare_binary_search(values, weights)
    local totals = {} -- 总和列表
    local sum = 0
    for i, w in ipairs(weights) do
        sum = sum + w
        totals[i] = sum
    end

    -- 返回选择器函数
    return function()
        local n = math.random() * sum
        local mid, distance
        local low, high = 0, #weights
        while low < high do
            mid = (low + high) // 2
            distance = totals[mid + 1]
            if distance < n then
                low = mid + 1
            elseif distance > n then
                high = mid
            else
                low = mid
                break
            end
        end
        return values[low + 1], weights[low + 1]
    end
end
