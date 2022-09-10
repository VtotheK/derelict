using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Extensions
{
    public static class FileExtensions
    {
        private static List<byte[]> ImageFileHeaders = new List<byte[]>()
        {
            new byte[] { 0x42, 0x4D},
            new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 },
            new byte[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 },
            new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
            new byte[] { 0xff, 0xd8 },
            new byte[] { 0x52, 0x49, 0x46, 0x46 }
        };

        public static bool IsImageFile(this FileStream file)
        {
            var len = ImageFileHeaders.OrderByDescending(x => x.Length).First().Length;
            var magic = new byte[len];
            using(var binaryReader = new BinaryReader(file, Encoding.UTF8))
            {
                for(int i = 0; i < len; ++i)
                {
                    magic[i] = binaryReader.ReadByte();
                    foreach(var bytes in ImageFileHeaders)
                    {
                        if(bytes.SequenceEqual(magic))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
