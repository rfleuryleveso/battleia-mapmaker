using System;
using System.Collections.Generic;
using System.Text;

namespace BattleIAMapMaker
{
    class Map
    {
        public (int, int) size = (0, 0);
        public List<List<MapTile>> map = new List<List<MapTile>>(); // x,y 

        public Map(int size_x, int size_y)
        {
            this.size = (size_x, size_y);
            this.regenMap();           
        }

        public void regenMap()
        {
            (int size_x, int size_y) = this.size;
            // Fill the v̵̱̜̮̲̜͌͐̎̉̔̓̉͂̚͝ǫ̷̛͎̭̟͆̽͒̐͒͛̈̏̑͂̚̕͘i̶̻̙͖̾͌̔͒͌̋̑͐͑́͑̄d̵̦̙͍̩̩͇͓̅̓
            this.map.Clear();
            for (int i_x = 0; i_x < size_x; i_x++)
            {
                List<MapTile> column = new List<MapTile>();
                for (int i_y = 0; i_y < size_y; i_y++)
                {
                    column.Add(new MapTile(i_x, i_y, MapTileType.VOID));
                }
                this.map.Add(column);
            }
        }
        public String serializeMap()
        {
            (int size_x, int size_y) = this.size;
            String output = "";
            for (int i_y = 0; i_y < size_y; i_y++)
            {
                for (int i_x = 0; i_x < size_x; i_x++)
                {
                    output += this.map[i_x][i_y].getChar();
                }
                output += '\n';
            }
            
            return output;
        }
    }
}
