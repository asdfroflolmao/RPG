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

            if (level == 4) /// water level.
            {
                Rows = new List<MapRow>();
                for (int y = 0; y < MapHeight; y++)
                {
                    MapRow thisRow = new MapRow();
                    for (int x = 0; x < MapWidth; x++)
                    {
                        thisRow.Columns.Add(new MapCell(2));
                    }
                    Rows.Add(thisRow);
                }

                for (int i = 0; i < 50; i++)
                { Rows[0].Columns[i].TileID = 1; }
                for (int j = 0; j < 50; j++)
                { Rows[18].Columns[j].TileID = 1; }
                for (int k = 0; k < 50; k++)
                { Rows[k].Columns[0].TileID = 1; }
                for (int l = 0; l < 50; l++)
                { Rows[l].Columns[24].TileID = 1; }

          
                for (int m = 0; m < 11; m++)
                { Rows[m].Columns[m].TileID = 1; }
                for (int n = 0; n < 11; n++)
                { Rows[18-n].Columns[n].TileID = 1; }
                for (int o = 0; o < 11; o++)
                { Rows[o].Columns[24-o].TileID = 1; }
                for (int p = 0; p < 11; p++)
                { Rows[18 - p].Columns[24-p].TileID = 1; }

                for (int q = 8; q < 17; q++)
                { Rows[8].Columns[q].TileID = 1; }
                for (int r = 8; r < 17; r++)
                { Rows[9].Columns[r].TileID = 1; }
                for (int s = 8; s < 17; s++)
                { Rows[10].Columns[s].TileID = 1; }

            }

        }


    }
}
