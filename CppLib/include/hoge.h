#pragma once

#include <Windows.h>
#include <cstdint>

#ifdef HOGELIB_EXPORTS
#define HOGELIB_API __declspec(dllexport)
#else
#define HOGELIB_API __declspec(dllimport)
#endif

#pragma pack(push, 0)
struct Hoge
{
    uint8_t byteValue;
    int16_t shortValue;
    int32_t intValue;
    bool boolValue;
    int64_t longValue;
};
#pragma pack(pop)

extern "C" {
    HOGELIB_API void WINAPI LoadHogeFromCpp(Hoge* hoge);
    HOGELIB_API void WINAPI StoreHogeToCpp(const Hoge* hoge);
}
