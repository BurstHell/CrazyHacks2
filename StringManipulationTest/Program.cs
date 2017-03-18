using CrazyHacks.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringManipulationTest
{
    class Program
    {
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }
        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        static void Main(string[] args)
        {
            byte[] r1 = Zip("StringStringStringStringStringStringStringStringStringStringStringStringStringString");
            string r2 = Unzip(r1);
            Console.WriteLine(Convert.ToBase64String(r1));
        }

        static void Test003(string[] args) {
            FilterConfig fc = new FilterConfig();

            fc.Clear();
        }
        static void Test002(string [] args)
        {

            Regex r = new Regex(@"^https?:\/\/www.yes24.com", RegexOptions.IgnoreCase);
            Match m = r.Match("http://www.yes24.com/blablablla/");
            if (m.Success) {
                Console.WriteLine("Success");
            }
        }

        static void Test001(string[] args)
        {
            string url1 = "www.example.com/example";

            string[] splitUrl1 = url1.Split('/');

            string url2 = "www.example.com";

            string[] splitUrl2 = url2.Split('/');

            Console.WriteLine(splitUrl2[0]);

            Console.ReadLine();
        }
    }
}
