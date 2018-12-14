﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Organiser
{
    public partial class DialogBox : Form
    {
        public string textboxdata;
        public string boxTitle = DialogBox.ActiveForm.Text;
        public string labelText;

        public DialogBox()
        {
            InitializeComponent();
            labelText = label2.Text;
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {
            if (textboxdata != null)
            {
                textBox.Text = textboxdata;
            }
            textboxdata = "";
        }

        private void _acceptBtn_Click(object sender, EventArgs e)
        {
            textboxdata = textBox.Text;
        }

        private void _cancelBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
