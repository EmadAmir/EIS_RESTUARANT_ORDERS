﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Form1 WelcomeForm = new Form1();
            Form2 SelectUser = new Form2();
            //WelcomeForm.Close();
            SelectUser.ShowDialog();
            Visible = false;
           

        }
    }
}
