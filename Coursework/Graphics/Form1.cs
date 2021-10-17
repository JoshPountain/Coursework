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
            //camera always positioned in middle of render area!!!!
            int renderDist = 100;
            renderDist *= 2;
            int[,,] space = new int[renderDist, renderDist, renderDist];

            int[,,] render = space;
            //x, y, z
            double[] zero2 = new double[2] { 0, 0 };
            double[] zero3 = new double[3] { 0, 0, 0 };
            int[] pos = new int[2] { 50, 50 };
            int i = 0;
            var test = new Objects[100];
            var cam = new Camera(100);

            //cam.checkDebug();
            //cam.rotate(90, 0);
            //cam.checkDebug();

            //test[0] = new Objects(10, pos, 2);
            //go through all objects
            //equation to tell which objects can be seen
            /*foreach (object t in test)
            {
                i++;
            }
            Console.WriteLine(i.ToString());
            Objects o = test[0];
            o.tryMe();*/

            //double h = o.radius;
            //cam.checkDebug();
            cam.rotate(180, 0);
            //cam.checkDebug();
        }
    }
}
