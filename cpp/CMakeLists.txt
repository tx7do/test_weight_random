cmake_minimum_required(VERSION 3.16)

project(test_weight_random)

set(CMAKE_CXX_STANDARD 20)

# 设置动态库的输出目录
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}/lib)
# 设置静态库的输出目录
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}/lib)

# For debug libs and exes, add "-d" postfix
set(CMAKE_DEBUG_POSTFIX "d")

#add_subdirectory(WeightRandom)
add_subdirectory(Test)
