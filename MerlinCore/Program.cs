using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MerlinCore.Voice;

namespace MerlinCore
{
    static class Program
    {
        static void Main(string[] args)
        {
            MicrosoftSpechMerlinCore th = new MicrosoftSpechMerlinCore();
            //-------------------------------------------------------
            //th.inicializer();
            MerlinInterface mi = new MerlinInterface();
            mi.initial();
            Console.ReadKey();
        }
    }
}
