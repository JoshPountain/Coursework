using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        Objects[] obj = new Objects[100];
        int objInRender = 0;
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
            int[] point = new int[3] { 1, -1, 1 };
            //c.setRotation(0, 0);

            //Not doing setup when testing
            //setup();
            testing();

            //c.getPerspective(point);
            createObject(point, 10, 1);
            
        }

        public void createObject(int[]pos, double mass, double radius)
        {
            //File.Create("C:\\Users\\josh1\\Desktop\\Coursework(git)\\Coursework\\Coursework\\bin\\Debug\\ObjectLog.txt");
            // string file = File.ReadAllText("C:\\Users\\josh1\\Desktop\\Coursework(git)\\Coursework\\Coursework\\bin\\Debug\\ObjectLog.txt");
            string file = File.ReadAllText("ObjectLog.txt");
            int id = Convert.ToInt32(file);
            obj[objInRender] = new Objects(mass, pos, radius, id);
        }

        public void createObject(int[] pos, double mass, double radius, double[] velocity)
        {
            string file = File.ReadAllText("ObjectLog.txt");
            int id = Convert.ToInt32(file);
            obj[objInRender] = new Objects(mass, pos, radius, 0);
            obj[objInRender].forceVector = velocity;
        }



        private void draw()
        {

        }

        private void testing()
        {
            double[] point, Rightrotation, test;
            
            Console.WriteLine("************************Rotation set 10, 10");
            
            c.setRotation(171, -54);
            point = c.facing;
            Rightrotation = c.rotation;
            //Mixup in output
            test = c.getPerspective(point);

            c.checkDebug();

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
            
        }
    }
}
