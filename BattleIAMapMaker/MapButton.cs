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

        public static Color colorFromComboIndex(int index)
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
        public static int comboIndexFromTileType(MapTileType index)
        {
            switch (index)
            {
                case MapTileType.VOID:
                    return 0;
                case MapTileType.BOT:
                    return 1;
                case MapTileType.WALL:
                    return 2;
                case MapTileType.ENNEMY:
                    return 3;
                case MapTileType.ENERGY:
                    return 4;
                case MapTileType.RESPAWN:
                    return 5;
                case MapTileType.RETURN_TO_START:
                    return 6;
                case MapTileType.RACE_FINISH:
                    return 7;
                case MapTileType.SPAWN_T1:
                    return 8;
                case MapTileType.SPAWN_T2:
                    return 9;
                case MapTileType.POISON:
                    return 10;
                default:
                    return 999;
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
