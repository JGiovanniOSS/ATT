﻿using SharedLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AIF.Scripts
{
    public class AIFMassUploadData:AIFBaseData
    {
        public AIFMassUploadData() {
            _guid = Guid.NewGuid().ToString();
        }

        private string _guid;

        private string getfile(string prefix) {
            //return prefix + $"_{TaskId}.txt";
            return prefix + $"_{TaskId}_{_guid}.txt";
        }

        private void removeFile(string file) {
            if (File.Exists(file))
                File.Delete(file);
        }

        public string GetUploadedFile() {
            string file = Path.Combine(GlobalConfig.AIFWorkDir, getfile("LH7_BD87"));
            return file;
        }

        public string GetIDocFile() {
            string file = Path.Combine(GlobalConfig.AIFWorkDir, getfile("LH1_IDoc"));
            return file;
        }

        public string GetDownloadFile() {
            return Path.Combine(GlobalConfig.AIFWorkDir,getfile("LH1_Data"));
        }

        public string GetIDocITGFile() {
            return Path.Combine(GlobalConfig.AIFWorkDir, getfile("LH7_IDoc"));
        }

        public SAPLoginData LH1 { get; set; }

        public DateTime Start { get; set; } = DateTime.Now;

        public DateTime End { get; set; } = DateTime.Now;

        public int DataCounts { get; set; } = 100;

        //public int IntervalDays { get; set; } = 2;

        //public int RetryCounts { get; set; } = 5;

        public string Status { get; } = "53";

        public string Direction { get; } = "2";

        [XmlIgnore]
        public int TaskId { get; set; }


       



    }
}
