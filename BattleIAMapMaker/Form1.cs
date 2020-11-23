using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleIAMapMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[] buttons = new Button[0];

        void displayGrid()
        {
            (int size_x, int size_y) = Program.map.size;

            this.groupBox1.Controls.Clear();
            this.buttons = new Button[size_x * size_y];
            for (int i_x = 0; i_x < size_x; i_x++)
            {
                List<MapTile> column = Program.map.map[i_x];
                for (int i_y = 0; i_y < size_y; i_y++)
                {
                    int buttonId = (i_x * size_x) + i_y;
                    Button cButton = this.buttons[buttonId] = new Button();
                    

                }
            }
        }

    }
}
