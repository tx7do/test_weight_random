cmake_minimum_required(VERSION 3.16)

project(test)

# C++版本
set(CMAKE_CXX_STANDARD 20)

# 将 src 目录下的所有源文件加入后面的变量之中
file(GLOB DIR_EXE_SRCS ./*.cpp)

add_executable(${PROJECT_NAME} ${DIR_EXE_SRCS})

# 指定目标链接的库
target_link_libraries(
        ${PROJECT_NAME}
        PRIVATE
#        weight_random
        dl
        rt
)
