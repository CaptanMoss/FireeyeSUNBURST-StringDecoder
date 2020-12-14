using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.Text;
using Microsoft.Win32;

namespace string_decoder
{
    class Program
    {
        public static byte[] Decompress(byte[] input)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(input))
            {
                using (MemoryStream memoryStream2 = new MemoryStream())
                {
                    using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
                    {
                        deflateStream.CopyTo(memoryStream2);
                    }
                    result = memoryStream2.ToArray();
                }
            }
            return result;
        }
        static void Main()
        {
            string result;
            byte[] bytes = Decompress(Convert.FromBase64String("i/EvyszP88wtKMovS81NzSuJCc7PSSwKz8xLKdZDl9NLrUgFAA=="));
            result = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(result);
        }
    }
}

//Rapor yaz icine snort yara clamav kurallarını ekle