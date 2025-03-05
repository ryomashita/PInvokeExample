#include "hoge.h"

namespace {
    Hoge storagedHoge;
}

void WINAPI StoreHogeToCpp(const Hoge* hoge)
{
    storagedHoge.byteValue = hoge->byteValue;
    storagedHoge.shortValue = hoge->shortValue;
    storagedHoge.intValue = hoge->intValue;
    storagedHoge.longValue = hoge->longValue;
    storagedHoge.boolValue = hoge->boolValue;
}

void WINAPI LoadHogeFromCpp(Hoge* hoge)
{
    hoge->byteValue = storagedHoge.byteValue;
    hoge->shortValue = storagedHoge.shortValue;
    hoge->intValue = storagedHoge.intValue;
    hoge->longValue = storagedHoge.longValue;
    hoge->boolValue = storagedHoge.boolValue;
}
