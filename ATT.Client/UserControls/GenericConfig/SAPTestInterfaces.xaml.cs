﻿using ATT.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace ATT.Client.UserControls.GenericConfig
{
    /// <summary>
    /// Interaction logic for Sources.xaml
    /// </summary>
    public partial class SAPTestInterfaces : ConfigBase<SAPInterfaces>
    {
        public SAPTestInterfaces() {
            InitializeComponent();
           //LoadDatas(d => d.SAPInterfaces.Include(s => s.SAPCompanyCodes).Include(s => s.SAPDocTypes).ToList());
        }
    }
}
