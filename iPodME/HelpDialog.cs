using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace iPodME
{
    partial class HelpDialog : Form
    {
        public HelpDialog(String helpPath)
        {
            InitializeComponent();
            helpBrowser.Url = new System.Uri(helpPath);
        }
    }
}
