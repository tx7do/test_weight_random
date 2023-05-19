cmake_minimum_required(VERSION 3.16)

project(weight_random)

set(CMAKE_CXX_STANDARD 20)

file(GLOB CORE_HEADER ./*.h)
file(GLOB CORE_SRC ./*.cpp)
set(CORE_COMPILE_CODE ${CORE_HEADER} ${CORE_SRC})

add_library(${PROJECT_NAME} SHARED ${CORE_COMPILE_CODE})
