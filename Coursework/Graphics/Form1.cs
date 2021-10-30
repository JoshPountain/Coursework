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

            /*c.setRotation(-30, 45);
            c.setRotation(30, 45);
            c.setRotation(45, 30);
            c.setRotation(45, -30);*/
            c.getPoint(30);
            //c.checkDebug();
            //c.checkDebug();
            //c.checkDebug();

        }
    }
}
