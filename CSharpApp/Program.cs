using System;
using System.Runtime.InteropServices;
// debug assert
using System.Diagnostics;

namespace CSharpApp
{
    // P/Invoke で使用する構造体は常に StructLayout を使い書式指定する必要がある。
    // Pack : アライメントを指定する。 default(0) では メンバーごとのアライメントが行われる。
    [StructLayout(LayoutKind.Sequential, Pack=0)]
    public class Hoge
    {
        public byte byteValue;
        public short shortValue;
        public int intValue;
        public bool boolValue;
        public long longValue;
    }

    class Program
    {
        // [Out] : 出力方向の Marshaling を行う (default は [In])
        // ※ Blittable な型の場合は Marshaling が不要なため [Out] [In] が無くても動作する。
        // 
        // Hoge は class ( = 参照型 ) なので、ref は不要。
        [DllImport("hoge.dll")]
        public static extern void LoadHogeFromCpp([Out] Hoge hoge);
        [DllImport("hoge.dll")]
        public static extern void StoreHogeToCpp(Hoge hoge);

        static void Main(string[] args)
        {
            // managed 側でメモリを確保する
            var expectHoge = new Hoge
            {
                byteValue = (byte)123,
                shortValue = (short)12345,
                intValue = (int)123456789,
                longValue = (long)1234567890123456789,
                boolValue = (bool)true,
            };
            
            StoreHogeToCpp(expectHoge);

            var actualHoge = new Hoge();
            LoadHogeFromCpp(actualHoge);

            Debug.Assert(expectHoge.byteValue == actualHoge.byteValue);
            Debug.Assert(expectHoge.shortValue == actualHoge.shortValue);
            Debug.Assert(expectHoge.intValue == actualHoge.intValue);
            Debug.Assert(expectHoge.longValue == actualHoge.longValue);
            Debug.Assert(expectHoge.boolValue == actualHoge.boolValue);
            Console.WriteLine("All tests passed!");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
