﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Scripts
{
    public class FileConfig
    {
        protected string _workDir;

        public FileConfig(string WorkFolder) {
            _workDir = Path.Combine(@"C:\ATT", WorkFolder);
            if (!Directory.Exists(_workDir))
                Directory.CreateDirectory(_workDir);
        }

        public string WorkDir { get { return _workDir; } }

        protected string getFile(string fileName) => Path.Combine(_workDir, fileName);
    }
}
