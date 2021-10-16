using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    class Camera
    {
        public Camera(double[] ilocation, double[] irotation)
        {
            rotation[0] = 0;
            rotation[1] = 0;
            rotation[2] = 0;
            location = rotation;

            location = ilocation;
            rotation = irotation;
            
        }
        public double[] location { get; set; }
        public double[] rotation { get; set; } = new double[3];
        public void Wmove(double amplifier)
        {
            location[0] += amplifier * (rotation[0]);
            location[1] += amplifier * (rotation[1]);
            location[2] += amplifier * (rotation[2]);
        }

    }
}
