﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Scripts
{
    public class PIITrackData: GUIShareData
    {
        public string WorkFolder { get; } = Path.Combine(GlobalConfig.AttWorkDir, "MSGID_Report");
       
    }
}
