#include "../include/hoge.h"

void WINAPI HogeFunction(Hoge* hoge)
{
    // 構造体のフィールドに値を設定
    hoge->byteValue = 123;
    hoge->shortValue = 12345;
    hoge->intValue = 1234567890;
    hoge->longValue = 1234567890123456789LL;
    hoge->boolValue = true;
}
