using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace Graphics
{
    class Camera
    {
        public Camera(int renderDist)
        {
            setRotation(0, 0);
            getPoint(30);
            checkDebug();
        }

        public double[] location { get; set; } = new double[3] { 1, 0, 0 };
        public double[] facing { get; set;} = new double[3] { 0, 0, 0 };
        public double[] rotation { get; set; } = new double[2];
        double[] mleft = new double[3], mright = new double[3], mback = new double[3], mforward = new double[3];

        //Height, width (fov)
        public double[] fov { get; set; } = new double[2] { 30, 30 };
        

        public void setRotation(double Atheta, double Av)
        {
            
            while (Math.Abs(Av) > 90)
            {
                if (Av < 0)
                {
                    Atheta += 180;
                    Av = -90 - (Av + 90);
                }
                else
                {
                    Atheta += 180;
                    Av = 90 - (Av - 90);
                }
            }
            while (Atheta >= 360)
            {
                Atheta -= 360;
            }


            Console.WriteLine("ANGLE: " + Atheta.ToString());
            //trig angles to find new facing point
            rotation[0] = 0;
            rotation[1] = 0;
            //facing[0] = 0;
            //facing[1] = 0;
            //facing[2] = 0;

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
            if (Av != 0)
            {
                z = (Av / Math.Abs(Av)) * Math.Sin(Math.Abs(Av) * CONVERT);
            }
            else
            {
                z = Math.Sin(Math.Abs(Av) * CONVERT);
            }
            
            //Console.WriteLine(Av.ToString());
            //Console.WriteLine("Sign: " + (Math.Abs(Av) / Av).ToString());
            if (Av == 90)
            {
                //Vertical rotation
                proportion = 0;
            }
            else
            {
                proportion = Math.Cos(Av * CONVERT);
            }
            
            Console.WriteLine(proportion);
            Console.WriteLine("Proportion: " + proportion.ToString());
            sin = (Math.Sin((modifier - Atheta) * CONVERT)) * proportion;
            cos = (Math.Cos((modifier - Atheta) * CONVERT)) * proportion;
            //cos = Math.Cos((modifier - 90) * CONVERT) * proportion;
            
            cos = Math.Sin((Atheta - (modifier - 90)) * CONVERT) * proportion;
            //cos = Math.Sin(90 * (Math.PI / 180));
            //Console.WriteLine("Cos: " + cos.ToString());
            /*if (cos == 0)
            {
                Console.WriteLine("Huh");
            }*/
            switch (modifier)
            {
                case 90:
                    y += sin;
                    //x += cos;
                    Console.WriteLine("Check: " + (Math.Sin(90 * CONVERT)).ToString());
                    Console.WriteLine("Atheta: " + Atheta.ToString());
                    //x += Math.Sin(Atheta * CONVERT);
                    x += cos;
                    Console.WriteLine(modifier.ToString());
                    break;
                case 180:
                    x += sin;
                    y -= cos;
                    Console.WriteLine(modifier.ToString());
                    break;
                case 270:
                    y -= sin;
                    x -= cos;
                    Console.WriteLine(modifier.ToString());
                    break;
                case 360:
                    x -= sin;
                    y += cos;
                    Console.WriteLine(modifier.ToString());
                    break;
            }
            Console.WriteLine("x: " + x.ToString());
            Console.WriteLine("y: " + y.ToString());
            Console.WriteLine("z: " + z.ToString());
            facing[0] += location[0] + x;
            facing[1] += location[1] + y;
            facing[2] += location[2] + z;
            //rotation[0] = Atheta;
            //rotation[1] = Av;
        }

        public void rotate(double Atheta, double Av, double noCol)
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

        public int[] DrawObject(double[] pos, int id, int[] screen)
        {
            //For testing
            pos = new double[3] { 50, 50, 50 };
            
            double dist = getDist(pos);
            //Would use id to get radius from database, but not set up
            double[] objAngles = ReturnAngle(pos);
            int x, y;
            int[] coordinates = new int[2];
            int[] angles = new int[2];
            int i = 0;
            foreach(double d in objAngles)
            {
                angles[i] = Convert.ToInt32(objAngles);
                i++;
            }

            int[] test = new int[2] { 10, 10 };
            angles = test;

            coordinates[0] = screen[0]/2 + Convert.ToInt32(angles[0] / 30);
            coordinates[1] = screen[1]/2 - Convert.ToInt32(angles[1] / 60);

            return coordinates;
            
        }

        public double[] getPerspective(double[] pos)
        {
            double[] point = new double[3];
            /*double[] rotationStore = rotation;
            setRotation(pos[0], pos[1]);
            point = facing;
            setRotation(rotationStore[0], rotationStore[1]);*/
            double[] dif = new double[3];
            foreach(int i in Enumerable.Range(0, 3))
            {
                dif[i] = Math.Abs(location[i] - pos[0]);
            }



            return point;
        }

        public double getDist(double[] position)
        {
            double dist = 0;
            dist = Math.Sqrt((Math.Pow(position[0] - location[0], 2) + (Math.Pow(position[1] - location[1], 2)) + (Math.Pow(position[2] - location[2], 2))));
            return dist;
        }

        public double[] ReturnAngle(double[] point)
        {
            //gets the frame the camera is 'looking at'
            double[,] frame = getPoint(30);
            double cx = location[0];
            double cy = location[1];
            double cz = location[2];
            double[] angles = new double[2];
            //plot lines from edge of screen, check if point is 'in bounds'
            //frane[4,3]
            //0 : top, 1 : bottom, 2: left, 3 : right

            double t;

            

            //find dist from cam pos to point
            //Pythagoras to find distances
            double xDist = point[0] - cx;
            double yDist = point[1] - cy;
            double zDist = point[1] - cz;
            double Dist = Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2) + Math.Pow(zDist, 2));
            switch (Dist)
            {
                case 0:
                    //no div by 0 error
                    t = 0.1;
                    break;
                default:
                    t = Math.Abs(Dist);
                    break;
            }

            //error if (yDist / t) == 0
            double Atheta = Math.Asin(yDist / t);
            switch (Atheta)
            {
                case 0:
                    Atheta = 0;
                    break;
                default:
                    Atheta = Math.Abs(Atheta);

                    break;
            }
            Atheta *= 180 / Math.PI;
            Atheta = 90 - Atheta;

            double Av = Math.Atan(zDist / t);
            switch (Av)
            {
                case 0:
                    //no div by 0 error
                    Av = 0;
                    break;
                default:
                    Av = Math.Abs(Av);

                    break;
            }

            Av *= 180 / Math.PI;

            angles[0] = Atheta;
            angles[1] = Av;
            return angles;
        }

        public bool ValidatePoint(double[] point)
        {
            //Sees if a point is in view of the camera
            bool inView = false;
            //gets the frame the camera is 'looking at'
            double[,] frame = getPoint(30);
            double cx = location[0];
            double cy = location[1];
            double cz = location[2];
            //plot lines from edge of screen, check if point is 'in bounds'
            //frane[4,3]
            //0 : top, 1 : bottom, 2: left, 3 : right

            foreach(int i in Enumerable.Range(0, 4))
            {
                double t;
                
                //Use parametrice to get equation for 3d line
                //x
                double ex = frame[i, 0];
                
                //y
                double ey = frame[i, 1];
                
                //z
                double ez = frame[i, 2];

                //find dist from cam pos to point
                //Pythagoras to find distances
                double xDist = point[0] - cx;
                double yDist = point[1] - cy;
                double zDist = point[1] - cz;
                double Dist = Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2) + Math.Pow(zDist, 2));
                switch (Dist)
                {
                    case 0:
                        //no div by 0 error
                        t = 0.1;
                        break;
                    default:
                        t = Math.Abs(Dist);
                        break;
                }

                //error if (yDist / t) == 0
                double Atheta = Math.Asin(yDist / t);
                switch (Atheta)
                {
                    case 0:
                        Atheta = 0;
                        break;
                    default:
                        Atheta = Math.Abs(Atheta);

                        break;
                }
                Atheta *= 180 / Math.PI;
                Atheta = 90 - Atheta;

                double Av = Math.Atan(zDist / t);
                switch (Av)
                {
                    case 0:
                        //no div by 0 error
                        Av = 0;
                        break;
                    default:
                        Av = Math.Abs(Av);

                        break;
                }
                Av *= 180 / Math.PI;


                //Here
                switch (i)
                {
                    case 0:
                        if (Av <= fov[0] + rotation[0] && Atheta <= fov[1] + rotation[1])
                        {
                            inView = true;
                            break;
                        }
                        else
                        {
                            inView = false;
                            break;
                            
                        }
                }

                if(inView == false)
                {
                    break;
                }

                //double px = cx - ex;
                //double x = cx - ex * t;
                //double y = cy - ey * t;
                //double z = cz - ez * t;
                
                //rearrange x and z
                //x : t = (cx-x)/ex
                //z : t = (cz-z)/ez

                // x into y
                //y = cy - (ey)*((cx-x)/ex)
                //0 = cy - (ey)*((cx-x)/ex) - y

                // z into y
                //y = cy - (ey)*((cz-z)/ez)
                //0 = cy - (ey)*((cz-z)/ez) - y

                //combine
                //cy - (ey)*((cz-z)/ez) - y = cy - (ey)*((cx-x)/ex) - y
                //(ey)*((cz-z)/ez)  =(ey)*((cx-x)/ex) 
                //((cz-z)/ez)  =((cx-x)/ex) 


            }

            return inView;
        }

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
        
        public double[,] getPoint(double fov)
        {
            //top, bottom, left, right
            double[,] points = new double[4, 3];
            double Atheta = 0, Av = 0;
            bool upper, lower, left, right;
            // start loop *****************************************************
            foreach(int i in Enumerable.Range(0, 4))
            {
                switch (i)
                {
                    case 0:
                        //top
                        Atheta = rotation[0];
                        Av = rotation[1] + fov;
                        break;
                    case 1:
                        //bottom
                        Atheta = rotation[0];
                        Av = rotation[1] - fov;
                        break;
                    case 2:
                        //left
                        Atheta = rotation[0] - fov;
                        Av = rotation[1];
                        break;
                    case 3:
                        //right
                        Atheta = rotation[0] + fov;
                        Av = rotation[1];
                        break;
                        


                }
                while (Math.Abs(Av) > 90)
                {
                    if (Av < 0)
                    {
                        Atheta += 180;
                        Av = -90 - (Av + 90);
                    }
                    else
                    {
                        Atheta += 180;
                        Av = 90 - (Av - 90);
                    }
                }
                while (Atheta >= 360)
                {
                    Atheta -= 360;
                }


                Console.WriteLine("ANGLE: " + Atheta.ToString());
                //trig angles to find new facing point
                //rotation[0] = 0;
                //rotation[1] = 0;
                //facing[0] = 0;
                //facing[1] = 0;
                //facing[2] = 0;

                //rotation[0] += Atheta;
                //rotation[1] += Av;
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
                if (Av != 0)
                {
                    z = (Av / Math.Abs(Av)) * Math.Sin(Math.Abs(Av) * CONVERT);
                }
                else
                {
                    z = Math.Sin(Math.Abs(Av) * CONVERT);
                }

                //Console.WriteLine(Av.ToString());
                //Console.WriteLine("Sign: " + (Math.Abs(Av) / Av).ToString());
                if (Av == 90)
                {
                    //Vertical rotation
                    proportion = 0;
                }
                else
                {
                    proportion = Math.Cos(Av * CONVERT);
                }

                Console.WriteLine(proportion);
                Console.WriteLine("Proportion: " + proportion.ToString());
                sin = (Math.Sin((modifier - Atheta) * CONVERT)) * proportion;
                cos = (Math.Cos((modifier - Atheta) * CONVERT)) * proportion;
                //cos = Math.Cos((modifier - 90) * CONVERT) * proportion;

                cos = Math.Sin((Atheta - (modifier - 90)) * CONVERT) * proportion;
                //cos = Math.Sin(90 * (Math.PI / 180));
                //Console.WriteLine("Cos: " + cos.ToString());
                /*if (cos == 0)
                {
                    Console.WriteLine("Huh");
                }*/
                switch (modifier)
                {
                    case 90:
                        y += sin;
                        //x += cos;
                        Console.WriteLine("Check: " + (Math.Sin(90 * CONVERT)).ToString());
                        Console.WriteLine("Atheta: " + Atheta.ToString());
                        //x += Math.Sin(Atheta * CONVERT);
                        x += cos;
                        Console.WriteLine(modifier.ToString());
                        break;
                    case 180:
                        x += sin;
                        y -= cos;
                        Console.WriteLine(modifier.ToString());
                        break;
                    case 270:
                        y -= sin;
                        x -= cos;
                        Console.WriteLine(modifier.ToString());
                        break;
                    case 360:
                        x -= sin;
                        y += cos;
                        Console.WriteLine(modifier.ToString());
                        break;
                }
                points[i, 0] = x;
                points[i, 1] = y;
                points[i, 2] = z;
                
            }
            //End loop *****************************************************************************************
            /*Console.WriteLine("x: " + x.ToString());
            Console.WriteLine("y: " + y.ToString());
            Console.WriteLine("z: " + z.ToString());*/

            /*facing[0] += location[0] + x;
            facing[1] += location[1] + y;
            facing[2] += location[2] + z;*/
            /*points[0] = x;
            points[1] = y;
            points[2] = z;*/
            //rotation[0] = Atheta;
            //rotation[1] = Av;

            //Set movement
            
            foreach(int i in Enumerable.Range(0, 3))
            {
                //left(right - left)
                mleft[i] = points[3, i] - points[2, i];
                //right(left - right)
                mright[i] = points[2, i] - points[3, i];
                

            }



            return points;
        }
        
        public void rotate(double rh, double rv)
        {
            setRotation(rh + rotation[0], rv + rotation[1]);
        }

        public void createFrame(int fov)
        {
            //gradients
            double x;
            double y;
            double z;
            double xDiff;
            double yDiff;
            double zDiff;

            //plotting line from camera position to the point looking at;


        }

        public void getDirection()
        {
            double[] dir = new double[3];

            double Atheta = rotation[0];
            double Av = rotation[1];
            
            foreach(int i in Enumerable.Range(0, 3))
            {
                //Forwards[(facing-position)/2]
                mforward[i] = (facing[i] - location[i]) / 2;
                //Backwards[(position-facing)/2]
                mback[i] = (location[i] - facing[i] / 2);
            }

        }
        
        public void move(double amplifier, int direction)
        {
            getDirection();
            while (direction >= 4)
            {
                direction -= 4;
            }
            move:
            switch (direction)
            {
                case 0:
                    //Forwards
                    foreach(int i in Enumerable.Range(0, 3))
                    {
                        location[i] += mforward[i] * amplifier;
                    }
                    break;
                case 1:
                    //backwards
                    foreach (int i in Enumerable.Range(0, 3))
                    {
                        location[i] += mback[i] * amplifier;
                    }
                    break;
                case 2:
                    //left
                    foreach (int i in Enumerable.Range(0, 3))
                    {
                        location[i] += mleft[i] * amplifier;
                    }
                    break;
                case 3:
                    //right
                    foreach (int i in Enumerable.Range(0, 3))
                    {
                        location[i] += mright[i] * amplifier;
                    }
                    break;
                default:
                    direction = 0;
                    goto move;

            }
        }

    }
}
