local function benchmarks()
    local values = {}
    local weights = {}
    for i = 1, 10000 do
        values[i] = i
        weights[i] = math.random(1, 1000)
    end

    local randomizers = {
        {"Linear Scan", prepare_line_scan(values, weights)},
        {"Binary Search", prepare_binary_search(values, weights)},
        {"Hopscotch Selection", prepare_hopscotch_selection(values, weights)},
        {"Alias Method ", prepare_aliased_randomizer(values, weights)}
    }

    for _, randomizer in ipairs(randomizers) do
        local tm = os.clock()
        for i = 0, 10000 do
            randomizer[2]()
        end
        print(string.format("%s time = %s", randomizer[1], os.clock() - tm))
    end
end

benchmarks()
