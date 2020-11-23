namespace BattleIAMapMaker
{
    enum MapTileType
    {
        VOID = 0x1,
        WALL = 0x2,
        ENERGY = 0x3,
        BOT = 0x4,
        CUSTOM_T
    }

    public class MapTile
    {
        readonly int x;
        readonly int y;

        MapTileType tileType;
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
    }
}