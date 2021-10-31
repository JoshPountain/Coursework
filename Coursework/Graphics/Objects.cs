using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    class Objects
    {

        public Objects(double imass, int[] ilocation, double iradius)
        {
            mass = imass;
            location = ilocation;
            radius = iradius;
        }
        public double mass { get; set; }
        public int[] location { get; set; }
        public double radius { get; set; }
        public double[] forceVector { get; set; } = new double[3] { 0, 0, 0 };



        public double[] gravity(double[] position, double otherMass)
        {
            //x,  y, z
            double[] modifiers = new double[3];

            //FORCEg = (G*M*m)/seperation^2)
            //where m is own mass, M is other mass and G is (6.67*10^-11)
            double r = getDist(position);
            double g = 6.67 * Math.Pow(10, -11);
            double force = (mass * otherMass * g) / Math.Pow(r, 2);
            double x, y, z;
            x = (position[0] - location[0]) * force;
            y = (position[1] - location[1]) * force;
            z = (position[2] - location[2]) * force;
            modifiers[0] = x;
            modifiers[1] = y;
            modifiers[2] = z;
            return modifiers;
        }
        public double getDist(double[] position)
        {
            double dist= 0;
            dist = Math.Sqrt((Math.Pow(position[0] - location[0], 2) + (Math.Pow(position[1] - location[1], 2)) + (Math.Pow(position[2] - location[2], 2))));
            return dist;
        }
        
        
        
    }
}
