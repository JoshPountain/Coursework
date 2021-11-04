using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{

    public partial class Form1 : Form
    {
        System.Drawing.Graphics graph;
        Camera c = new Camera(100);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            /*System.Drawing.Graphics graphics;
            graphics = pbWindow.CreateGraphics();
            Bitmap map = new Bitmap(100, 100);
            graph = System.Drawing.Graphics.FromImage(map);
            
            setup();
            double[] point = new double[3] { 1, 2, 0 };
            int[] screen = new int[2];
            int[] centre = c.DrawObject(point, 0, screen);*/
            double[] point = new double[3] { 1, -1, 1 };
            //c.setRotation(0, 0);
            setup();
            c.getPerspective(point);
            
        }

        private void draw()
        {

        }

        private void setup()
        {
            //trig right angle from camera to centre will give furthest side point cam can see
            //need formula for working out which way the camera is looking.
            //Have point the camera is looking at!!!

            
            
            
            //double[] yes = c.ReturnAngle(point);
            Console.WriteLine("DOING NOW");
            c.setRotation(45, 45);
            c.checkDebug();
            /*c.setRotation(-30, 45);
            c.setRotation(30, 45);
            c.setRotation(45, 30);
            c.setRotation(45, -30);*/
            //test at points where there should be shared coordinates
            //c.setRotation(0, 0);
            //c.getPoint(30);
            //double[] point = new double[3] { 0, 0, 0 };
            //c.ValidatePoint(point);
            //c.checkDebug();
            //c.checkDebug();
            //c.checkDebug();

        }
    }
}
