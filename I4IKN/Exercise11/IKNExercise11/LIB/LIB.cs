﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB
{
    public class LIB
    {
        /// <summary>
        /// Extracts the name of the file.
        /// </summary>
        /// <returns>
        /// The filename only.
        /// </returns>
        /// <param name='fileName'>
        /// Filename with path.
        /// </param>
        public static String extractFileName(String fileName)
        {
            return (fileName.LastIndexOf('/') == 0 ? fileName : fileName.Substring(fileName.LastIndexOf('/') + 1));
        }

        /// <summary>
        /// Check_s the file_ exists.
        /// </summary>
        /// <returns>
        /// The filesize.
        /// </returns>
        /// <param name='fileName'>
        /// The filename.
        /// </param>
        public static long check_File_Exists(String fileName)
        {
            if (File.Exists(fileName))
                return (new FileInfo(fileName)).Length;

            return 0;
        }
    }
}
