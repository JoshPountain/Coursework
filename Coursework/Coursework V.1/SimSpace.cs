using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_V._1
{
    class SimSpace
    {
        
        
    }
    class camera
    {
        private int xPos { get; }
        private int yPos { get; }
        private int zPos { get; }
        private int xRot { get; }
        private int yRot { get; }

        public void move(int x, int y, int z)
        {
            
        }

    }
    abstract class Object
    {
        private Array[,,] space;
        private double mass { get; set; }
        private int xPos { get; set; }
        private int yPos { get; set; }
        private int zPos { get; set; }
        private double diameter { get; set; }
        private string texture { get; }
        private double gravity { get; } = 1;
        
        abstract class planet : Object
        {
            
            private int hardness { get; set; }
            private int hitbox { get; set; }
            class classic : planet
            {

            }
            class gasGiant : planet
            {

            }
        }
        class star : Object
        {
            private int temperature { get; set; }
            private int type { get; set; }
        }
        class satellite : Object
        {
            
        }
        class blackHole : Object
        {
            private double pullMultiplier { get; set; }
        }
    }
}
