using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BattleIAMapMaker
{
    class MapButton: Button
    {

        static Color colorFromComboIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return Color.Transparent;
                case 1:
                    return Color.FromArgb(255, 0, 0);
                case 2:
                    return Color.FromArgb(0, 255, 0);
                case 3:
                    return Color.FromArgb(0, 0, 255);
                case 4:
                    return Color.FromArgb(255, 255, 0);
                case 5:
                    return Color.FromArgb(0, 255, 255);
                case 6:
                    return Color.FromArgb(255, 0, 255);
                case 7:
                    return Color.FromArgb(255, 255, 255);
                case 8:
                    return Color.FromArgb(0, 255, 128);
                default:
                    var md5 = MD5.Create();
                    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(index.ToString()));
                    return Color.FromArgb(hash[0], hash[1], hash[2]);
            }  
        }

        public int x = 0;
        public int y = 0;

        public void clickEvent(object sender, EventArgs e)
        {
            this.BackColor = colorFromComboIndex(Program.mainForm.comboBox1.SelectedIndex);
            Program.map.map[this.x][this.y].setTileType((MapTileType)Program.mainForm.comboBox1.SelectedIndex);
        }
    }
}
