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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_Shown(object sender, EventArgs e)
        {
            int[,,] space = new int[100, 100, 100];
            int[] objects;
            var test = new Objects[10];
            Objects o = test[0];
            o.tryMe();
        }
    }
}
