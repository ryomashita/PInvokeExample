using System;
using System.Runtime.InteropServices;

namespace CSharpApp
{
    [StructLayout(LayoutKind.Sequential)]
    public class Hoge
    {
        public byte byteValue;
        public short shortValue;
        public int intValue;
        public long longValue;
        public bool boolValue;
    }

    class Program
    {
        [DllImport("hoge.dll")]
        public static extern void HogeFunction([Out] Hoge hoge);

        static void Main(string[] args)
        {
            var hoge = new Hoge();

            Console.WriteLine("呼び出し前の値:");
            Console.WriteLine("byteValue: " + hoge.byteValue);
            Console.WriteLine("shortValue: " + hoge.shortValue);
            Console.WriteLine("intValue: " + hoge.intValue);
            Console.WriteLine("longValue: " + hoge.longValue);
            Console.WriteLine("boolValue: " + hoge.boolValue);

            HogeFunction(hoge);

            Console.WriteLine("\n呼び出し後の値:");
            Console.WriteLine("shortValue: " + hoge.shortValue);
            Console.WriteLine("byteValue: " + hoge.byteValue);
            Console.WriteLine("intValue: " + hoge.intValue);
            Console.WriteLine("longValue: " + hoge.longValue);
            Console.WriteLine("boolValue: " + hoge.boolValue);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
