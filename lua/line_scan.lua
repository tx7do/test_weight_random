-- 线性扫描
local function prepare_line_scan(values, weights)
    assert(#values == #weights)
    local sum = 0 -- 计算总权重
    for _, wt in ipairs(weights) do
        sum = sum + wt
    end
    return function()
        local n = math.random(1, sum) -- 线性扫描
        for idx, wt in ipairs(weights) do
            if n <= wt then
                return values[idx], weights[idx]
            end
            n = n - wt
        end
    end
end
