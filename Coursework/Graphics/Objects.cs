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
        
            
        
        
        public void tryMe()
        {
            Console.WriteLine("Hellothere");
        }
        public double GetMass()
        {
            return mass;
        }
        public double SetMass(double input)
        {
            mass = input;
            return mass;
        }
        
    }
}
