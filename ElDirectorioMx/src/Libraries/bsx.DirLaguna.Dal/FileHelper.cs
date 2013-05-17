using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace bsx.DirLaguna.Dal
{
    public class FileHelper
    {
        public static string GetFile(string path, string name)
        {
            string[] files = Directory.GetFiles(path, string.Format("{0}.*", name));

            if (files.Length == 0)
                return string.Empty;

            FileInfo info = new FileInfo(files[0]);
            return info.Name;
        }

        public static void DeleteExistingFiles(string path, string mask)
        {
            string[] files = Directory.GetFiles(path, mask);
            DeleteFiles(files);
        }

        private static void DeleteFiles(string[] files)
        {
            foreach (var item in files)
                File.Delete(item);
        }
    }
}
