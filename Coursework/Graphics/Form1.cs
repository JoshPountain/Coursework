using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            int[,,] space = new int[100, 100, 100];
            int[] objects;
            var test = new Objects[10];
            test[0] = new Objects();
            Objects o = test[0];
            o.tryMe();
            //test[0].tryMe();
        }
    }
}
