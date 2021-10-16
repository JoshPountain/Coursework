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
            //trig right angle from camera to centre will give furthest side point cam can see
            int[,,] space = new int[100, 100, 100];
            int[,,] render = space;
            int[] pos = new int[2] { 50, 50 };
            int i = 0;
            var test = new Objects[100];
            test[0] = new Objects(10, pos, 2);
            //go through all objects
            foreach (var t in test)
            {
                i++;
                Console.WriteLine(i.ToString());
            }

            Objects o = test[0];
            o.tryMe();
            double h = o.radius;
        }
    }
}
