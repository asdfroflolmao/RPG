using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class MapRow
    {
        public List<MapCell> Columns = new List<MapCell>();
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 50;
        public int MapHeight = 50;
        //int level;
    }

    class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 50;
        public int MapHeight = 50;

        public TileMap(int level)
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }

            if (level == 1)
            {
                for (int i = 4; i < 16; i++)
                {
                    Rows[i].Columns[11].TileID = 1;
                    Rows[i].Columns[12].TileID = 1;
                }

                Rows[3].Columns[9].TileID = 3;
                Rows[3].Columns[10].TileID = 3;
                Rows[3].Columns[11].TileID = 3;
                Rows[3].Columns[12].TileID = 3;
                Rows[3].Columns[13].TileID = 3;
                Rows[3].Columns[14].TileID = 3;
                Rows[2].Columns[9].TileID = 3;
                Rows[2].Columns[10].TileID = 3;
                Rows[2].Columns[11].TileID = 3;
                Rows[2].Columns[12].TileID = 3;
                Rows[2].Columns[13].TileID = 3;
                Rows[2].Columns[14].TileID = 3;
                Rows[1].Columns[9].TileID = 3;
                Rows[1].Columns[10].TileID = 3;
                Rows[1].Columns[11].TileID = 3;
                Rows[1].Columns[12].TileID = 3;
                Rows[1].Columns[13].TileID = 3;
                Rows[1].Columns[14].TileID = 3;
            }
            if (level == 2)
            {
                for (int i = 5; i < 16; i++)
                { Rows[15].Columns[i].TileID = 1; }
                for (int j = 2; j < 24; j++)
                {
                    Rows[j].Columns[5].TileID = 1;
                    Rows[j].Columns[6].TileID = 1;
                }
                for (int k = 9; k < 16; k++)
                {
                    Rows[k].Columns[14].TileID = 1;
                    Rows[k].Columns[15].TileID = 1;
                    Rows[k].Columns[16].TileID = 1;
                }
                Rows[2].Columns[12].TileID = 2;
                Rows[3].Columns[12].TileID = 2;
                Rows[4].Columns[12].TileID = 2;
                Rows[2].Columns[13].TileID = 2;
                Rows[3].Columns[13].TileID = 2;
                Rows[4].Columns[13].TileID = 2;
                Rows[2].Columns[14].TileID = 2;
                Rows[3].Columns[14].TileID = 2;
                Rows[4].Columns[14].TileID = 2;
            }

            if (level == 3)
            {
                for (int i = 5; i < 20; i++)
                { Rows[1].Columns[i].TileID = 1; }
                for (int j = 2; j < 20; j++)
                {
                    Rows[j].Columns[6].TileID = 1;
                    Rows[j].Columns[7].TileID = 1;
                }
                for (int k = 9; k < 16; k++)
                {
                    Rows[k].Columns[14].TileID = 3;
                    Rows[k].Columns[15].TileID = 3;
                    Rows[k].Columns[16].TileID = 3;
                }
                Rows[2].Columns[12].TileID = 2;
                Rows[3].Columns[12].TileID = 2;
                Rows[4].Columns[12].TileID = 2;
                Rows[2].Columns[13].TileID = 2;
                Rows[3].Columns[13].TileID = 2;
                Rows[4].Columns[13].TileID = 2;
                Rows[2].Columns[14].TileID = 2;
                Rows[3].Columns[14].TileID = 2;
                Rows[4].Columns[14].TileID = 2;
            }

        }


    }
}
