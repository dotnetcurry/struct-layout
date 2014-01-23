using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

// Read the article at http://www.dotnetcurry.com/ShowArticle.aspx?ID=971
namespace Samples
{
    //uses LayoutKind.Sequence by default
    public struct StructSeq
    {
        private readonly Byte mb;
        private readonly Int16 mx;
        public string a;
        public string b;
        public string c;
        public string d;
    }

    [StructLayout(LayoutKind.Auto)]
    public struct StructAuto
    {
        private readonly Byte mb;
        private readonly Int16 mx;
        public string a;
        public string b;
        public string c;
        public string d;
    }

    public sealed class Program
    {
        public static void Main()
        {
            StructSeq sq = new StructSeq();
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < 8000000; i++)
            {
                ProcessStructSeq(ref sq);
            }
            sw1.Stop();
            Console.WriteLine("Struct LayoutKind.Sequence (default) {0}", sw1.Elapsed.TotalMilliseconds);

            StructAuto so = new StructAuto();
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 0; i < 8000000; i++)
            {
                ProcessStructAuto(ref so);
            }
            sw2.Stop();
            Console.WriteLine("Struct LayoutKind.Auto (explicit) {0}", sw2.Elapsed.TotalMilliseconds);

            //if (sw1.Elapsed.TotalMilliseconds < sw2.Elapsed.TotalMilliseconds)
            //{
            //    Console.WriteLine("false");
            //}
            //else
            //{
            //    Console.WriteLine("true");
            //}

            Console.ReadLine();
        }

        public static void ProcessStructSeq(ref StructSeq structSeq)
        {
            structSeq.a = "1";
            structSeq.b = "2";
            structSeq.c = "3";
            structSeq.d = "4";            
        }

        public static void ProcessStructAuto(ref StructAuto structAuto)
        {
            structAuto.a = "1";
            structAuto.b = "2";
            structAuto.c = "3";
            structAuto.d = "4";            
        }
    }
}
