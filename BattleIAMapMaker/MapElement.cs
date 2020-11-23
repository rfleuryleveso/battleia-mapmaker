using System;

namespace BattleIAMapMaker
{
    public enum MapTileType: byte
    {
        VOID = 0x0,
        WALL = 0x1,
        ENERGY = 0x2,
        BOT = 0x3,
        ENNEMY = 0x4,
        RESPAWN = 0x5,
        RETURN_TO_START = 0x6,
        RACE_FINISH = 0x7,
        SPAWN_T1= 0x8,
        SPAWN_T2 = 0x9,
        CUSTOM_T
    }

    public class MapTile
    {
        readonly int x;
        readonly int y;

        public MapTileType tileType;
        byte customTileType = 0; // in case tileType == CUSTOM_T, must be defined to a one byte number.


        public MapTile(int x, int y, MapTileType tileType)
        {
            this.x = x;
            this.y = y;
            this.tileType = tileType;
        }

        byte getTileType()
        {
            return this.tileType == MapTileType.CUSTOM_T ? this.customTileType : (byte) this.tileType;
        }

        void setCustomTileType(byte cTileType)
        {
            this.tileType = MapTileType.CUSTOM_T;
            this.customTileType = cTileType;
        }

        public void setTileType(MapTileType tileType)
        {
            this.tileType = tileType;
        }

        public char getChar()
        {
            return this.tileType.ToString("X").ToCharArray()[1];
        }
    }
}