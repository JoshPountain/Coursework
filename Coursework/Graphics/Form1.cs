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
            setup();
        }
        private void setup()
        {
            //trig right angle from camera to centre will give furthest side point cam can see
            //need formula for working out which way the camera is looking.
            //Have point the camera is looking at!!!

            Camera c = new Camera(100);
            //c.checkDebug();
            //c.rotate(1, 1);
            /*c.setRotation(180, 91);
            c.setRotation(0, 89);
            c.setRotation(90, 1);
            c.setRotation(180, 1);
            c.setRotation(270, 1);
            c.setRotation(360, 91);*/
            c.setRotation(90, 10);
            c.setRotation(80, 5);
            c.rotate(10, 5);
            //c.checkDebug();
            //c.checkDebug();

        }
    }
}
