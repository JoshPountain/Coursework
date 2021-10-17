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

            /*location[0] = renderDist / 2;
            location[1] = location[0];
            location[2] = location[0];
            facing[0] = location[0];
            facing[1] = location[1];
            facing[2] = location[2] + 1;*/
        }
        public int[] location { get; set; } = new int[3] { 0, 0, 0 };
        public double[] facing { get; set;} = new double[3] { 0, 1, 0 };
        public double[] rotation { get; set; } = new double[2];
        public double[] fov { get; set; } = new double[2] { 0, 0 };

        

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
        public void rotate(double horizontal, double vertical)
        {
            //trig to find new facing point

            //Camera works by having a point it is 'looking' which is centeral to the camera view
            /*Mouse movements can move vertically and horizontally, to move where camera is looking, equations can be used to move the point
             * equally, keeping the point equal distance away; the equations are:
             * x = x + Cos(up)*(x+2*(Sin(side/2))*(Cos(side/2)))
             * y = y + Cos(up)*(y+(1-2*(Sin(Side/2))^2)
             * z = z - Sin(up)
             * These work for any [-360<= horizontal movement <= 360] [-360 <= vertical movement <= 360]
            */


            //x, y, z mixup
            double side = horizontal;
            double up = vertical;
            double hUp = up / 2;
            double hSide = side / 2;
            double x = facing[0];
            double y = facing[1];
            double z = facing[2];
            double k = 0;


            double a = (side / 2) * (Math.PI / 180);
            double b = 1 - Math.Sqrt(Math.Pow((2 * Math.Sin(a)), 2) - Math.Pow(((2 * Math.Sin(a)) * (Math.Sin(a))), 2));



            Console.WriteLine("UP val :" + up.ToString() + "  Side Val : " + side.ToString());
            Console.WriteLine("half UP val :" + hUp.ToString() + " Half Side Val : " + hSide.ToString());
            up = up * (Math.PI / 180);
            //side = side * (Math.PI / 180);
            hUp = hUp * (Math.PI / 180);
            hSide = hSide * (Math.PI / 180);
            Console.WriteLine("UP val :" + up.ToString() + "  Side Val : " + side.ToString());
            Console.WriteLine("half UP val :" + hUp.ToString() + " Half Side Val : " + hSide.ToString());
            while (true)
            {
                if(side <= 360)
                {
                    break;
                }
                else
                {
                    side -= 360;
                }
            }

            if (side <= 90)
            {
                k = 90 - side;
            }else if(side <= 180)
            {
                k = 180 - side;
            }else if(side <= 270)
            {
                k = 270 - side;
            }
            else
            {
                k = 360 - side;
            }

            //x = (x + (2 * (Math.Sin(horizontal / 2)) * (Math.Cos(horizontal / 2)))) - ((1 - Math.Cos(k))*(Math.Sin(k)));
            //z = (z + (1 - 2*Math.Pow(Math.Sin(horizontal / 2), 2))) - (1-Math.Cos(k)*(Math.Cos(k)));
            //y = y - Math.Sin(up);

            //Stage 1 equations

            x = 2 * Math.Sin(hSide) * Math.Cos(hSide);

            //y = 1 - 2 * Math.Pow(Math.Sin(side / 2), 2);
            //y = 1 - (2 * Math.Sin(90/2 * Math.PI / 180)) * Math.Sin(90 / 2 * Math.PI / 180);

            Console.WriteLine("x : " + x.ToString());
            Console.WriteLine("y : " + b.ToString());

            Console.WriteLine(Math.Sin(90 / 2 * Math.PI / 180).ToString());

            /*
             
            Console.WriteLine("x :" + x.ToString());
            x = x + Math.Cos(up) * (x + (2 * Math.Sin(side / 2) * Math.Cos(side / 2)));
            //x = Math.Cos(up) * (x + (2 * Math.Sin(side / 2) * Math.Cos(side / 2)));
            Console.WriteLine("New x: " + x.ToString());


            Console.WriteLine("z :" + z.ToString());
            //double temp = (z + (1 - (2 * Math.Pow(Math.Sin(side / 2), 2))));
            double temp = (1 - (2 * Math.Pow(Math.Sin(side / 2), 2)));

            double temp2 = 0("New z: " + z.ToString());


            Console.WriteLine("y :" + y.ToString());
            y = y - Math.Sin(up);
            Console.WriteLine("New y: " + y.ToString());
            */

            facing[0] = x;
            facing[1] = y;
            facing[2] = z;
        }
        public void Wmove(double amplifier)
        {
            /*location[0] += amplifier * (rotation[0]);
            location[1] += amplifier * (rotation[1]);
            location[2] += amplifier * (rotation[2]);*/
        }

    }
}
