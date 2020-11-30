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

        MapButton[] buttons = new MapButton[0];

        public void displayGrid()
        {
            (int size_x, int size_y) = Program.map.size;
            int buttonWidth = this.groupBox1.Width / size_x;
            int buttonHeight = this.groupBox1.Height / size_y;

            this.groupBox1.Controls.Clear();
            this.buttons = new MapButton[size_x * size_y];
            for (int i_x = 0; i_x < size_x; i_x++)
            {
                List<MapTile> column = Program.map.map[i_x];
                for (int i_y = 0; i_y < size_y; i_y++)
                {
                    int buttonId = (i_x * size_x) + i_y;
                    MapButton cButton = this.buttons[buttonId] = new MapButton();

                    cButton.Left = 5 + i_x * buttonWidth;
                    cButton.Top = 10 + i_y * buttonHeight;
                    cButton.Width = buttonWidth;
                    cButton.Height = buttonHeight;
                    cButton.BackColor = MapButton.colorFromComboIndex(MapButton.comboIndexFromTileType(column[i_y].tileType));
                    int buttonX = i_x;
                    int buttonY = i_y;
                    cButton.x = i_x;
                    cButton.y = i_y;
                    cButton.Click += new System.EventHandler(cButton.clickEvent);
                    this.groupBox1.Controls.Add(cButton);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x_size = Int32.Parse(this.textBox1.Text);
            int y_size = Int32.Parse(this.textBox2.Text);
            Program.map.size = (x_size, y_size);
            Program.map.regenMap();
            Program.mainForm.displayGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String serializedMap = Program.map.serializeMap();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "text file|*.txt";
            saveFileDialog1.Title = "Save a map File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                ASCIIEncoding ascii = new ASCIIEncoding();

                int byteCount = ascii.GetByteCount(serializedMap.ToCharArray(), 0, serializedMap.Length);
                Byte[]  bytes = new Byte[byteCount];
                int bytesEncodedCount = ascii.GetBytes(serializedMap.ToCharArray(), 0, serializedMap.Length, bytes, 0);
                fs.Write(bytes);


                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (int size_x, int size_y) = Program.map.size;
            for (int i =0; i< size_x; i++)
            {
                Program.map.map[i][0].setTileType(MapTileType.WALL);
            }
            for (int i = 0; i < size_x; i++)
            {
                Program.map.map[i][size_y-1].setTileType(MapTileType.WALL);
            }
            for (int i = 0; i < size_y; i++)
            {
                Program.map.map[0][i].setTileType(MapTileType.WALL);
            }
            for (int i = 0; i < size_y; i++)
            {
                Program.map.map[size_x-1][i].setTileType(MapTileType.WALL);
            }
            Program.mainForm.displayGrid();
        }
    }
}
