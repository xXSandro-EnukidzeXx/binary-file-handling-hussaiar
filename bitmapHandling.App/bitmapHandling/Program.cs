using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace BitmapFiles.App
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] logo = File.ReadAllBytes("sps.bmp");
            byte first = logo[0];
            byte second = logo[1];

            char b = 'B';
            char m = 'M';

            int res1 = first ^ (byte)b;
            int res2 = second ^ (byte)m;

            byte[] width = new byte[] { logo[18], logo[19], logo[20], logo[21]};
            string binWidth = elReverso(width);
            int pixWidth = Convert.ToInt32(binWidth, 2);
            Console.WriteLine("The Width of the image is {0}", pixWidth);

            byte[] height = new byte[] { logo[22], logo[23], logo[24], logo[25] };
            string binHeight = elReverso(height);
            int pixHeight = Convert.ToInt32(binHeight, 2);
            Console.WriteLine("The Height of the image is {0}", pixHeight);

            byte[] cd = new byte[] { logo[46], logo[47], logo[48], logo[49] };
            string binCd = elReverso(cd);
            int decCd = Convert.ToInt32(binCd, 2);
            Console.WriteLine("The number of colours in the image is {0}", decCd);
        }

        public static string elReverso(byte[] source)
        {
            string output = string.Empty;
            foreach(byte index in source)
            {
                output = Convert.ToString(index, 2) + output;
            }
            return output;
        }
    }
}