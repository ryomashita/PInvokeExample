#pragma once

#include <Windows.h>
#include <cstdint>

#ifdef HOGELIB_EXPORTS
#define HOGELIB_API __declspec(dllexport)
#else
#define HOGELIB_API __declspec(dllimport)
#endif

struct Hoge
{
    uint8_t byteValue;
    int16_t shortValue;
    int32_t intValue;
    int64_t longValue;
    bool boolValue;
};

extern "C" {
    HOGELIB_API void WINAPI HogeFunction(Hoge* hoge);
}
