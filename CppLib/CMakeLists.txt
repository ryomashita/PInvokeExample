cmake_minimum_required(VERSION 3.10)
project(HogeLib)

add_compile_options(/W4 /utf-8)

# Windows APIを使用するための定義
add_definitions(-DWIN32 -D_WINDOWS)

# DLLをエクスポートするための定義
add_definitions(-DHOGELIB_EXPORTS)

# ヘッダーファイルのディレクトリを指定
include_directories(include)

# ソースファイルを指定
set(SOURCES src/hoge.cpp)

# DLLを作成
add_library(hoge SHARED ${SOURCES})

# 出力ディレクトリを設定
set_target_properties(hoge PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
    LIBRARY_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/lib"
    ARCHIVE_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/lib"
)
