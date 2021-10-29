using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    class Camera
    {
        public Camera(int renderDist)
        {
            fov[0] = 10;
            fov[0] = 10;


            location[0] = renderDist / 2;

            location[0] = renderDist / 2;

            location[1] = location[0];
            location[2] = location[0];
            facing[0] = location[0];
            facing[1] = location[1];

            facing[2] = location[2] + 1;
        }
        public int[] location { get; set; } = new int[3] { 0, 0, 0 };
        public double[] facing { get; set;} = new double[3] { 0, 0, 1 };
        public double[] rotation { get; set; } = new double[2];
        public double[] fov { get; set; } = new double[2] { 0, 0 };

        


        //facing[2] = location[2] + 1;
        
        


        public void checkDebug()
        {
            //Outputs var values
            Console.WriteLine("Location:" + location[0]);
            Console.WriteLine(location[1]);
            Console.WriteLine(location[2]);
            foreach(int i in Enumerable.Range(0, 3))
            {
                Console.WriteLine("Location:" + i.ToString()+ " " + location[i].ToString());
            }
            foreach (int i in Enumerable.Range(0, 2))
            {
                Console.WriteLine("rotation:" + i.ToString()+ " " + rotation[i].ToString());
            }
            foreach (int i in Enumerable.Range(0, 2))
            {
                Console.WriteLine("FOV: " + i.ToString()+ " " + fov[i].ToString());
            }

            foreach (int i in Enumerable.Range(0, 3))
            {
                Console.WriteLine("facing:" + i.ToString() + " " + facing[i].ToString());
            }
        }
        

        public void rotate(double Atheta, double Av)
        {
            //trig angles to find new facing point
            rotation[0] += Atheta;
            rotation[1] += Av;
            //Cam position modifiers (Asif top down)
            double x = 0;
            double y = 0;
            double z = 0;
            //t is for x,y rotation, a is for the 'elevation'
            double t = rotation[0];
            double a = rotation[1];
            double modifier = 90;
            //Trig functions in c# use radeons, the convert value will make the output be in degrees
            double CONVERT = Math.PI / 180;
            double sin;
            double cos;
            double proportion;
            if (t >= 360)
            {
                t -= 360;
            }

            while (true)
            {
                if (t <= modifier)
                {
                    break;
                }
                else
                {
                    modifier += 90;
                }
            }
            
            z = (Av / Math.Abs(Av)) * Math.Sin(Av * CONVERT);
            proportion = Math.Cos(Av * CONVERT);

            sin = (Math.Sin((modifier - Atheta) * CONVERT)) * proportion;
            cos = (Math.Cos((modifier - Atheta) * CONVERT)) * proportion;

            switch (modifier)
            {
                case 90:
                    y += sin;
                    x += cos;
                    break;
                case 180:
                    x += sin;
                    y -= cos;
                    break;
                case 270:
                    y -= sin;
                    x -= cos;
                    break;
                case 360:
                    x -= sin;
                    y += cos;  
                    break;
            }

            facing[0] += x;
            facing[1] += y;
            facing[2] += z;

        }
        public void Wmove(double amplifier)
        {
            /*location[0] += amplifier * (rotation[0]);
            location[1] += amplifier * (rotation[1]);
            location[2] += amplifier * (rotation[2]);*/
        }

    }
}
