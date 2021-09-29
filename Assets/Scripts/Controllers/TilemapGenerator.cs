using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC
{
    public class TilemapGenerator
    {
        private Tilemap _tileMap;
        private Tile _groundTile;
        private int _mapWidth;
        private int _mapHeight;
        private bool _borders;
        private int _factorSmooth;
        private int _fillPercecnt;

        private int[,] _map;

        private int CountWall = 4;
        private MarchingSquaresGenerator _march = new MarchingSquaresGenerator();

        public TilemapGenerator(GeneratorLevelView levelView)
        {
            _tileMap = levelView.TileMap;
            _groundTile = levelView.GroundTile;
            _mapWidth = levelView.MapWidth;
            _mapHeight = levelView.MapHeight;
            _borders = levelView.Borders;
            _factorSmooth = levelView.FactorSmooth;
            _fillPercecnt = levelView.FillPercecnt;

            _map = new int[_mapWidth, _mapHeight];
        }

        public void Start()
        {
            //random fill
            RandomFillMap();

            //smooth array
            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }

            _march.GeneratorInit(_map, 1);
            _march.DrawTiles(_tileMap, _groundTile);

            //draw tiles
            //DrawTiles();
        }

        private void RandomFillMap()
        {
            System.Random rand = new System.Random(Time.deltaTime.ToString().GetHashCode());

            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if(x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _map[x, y] = (rand.Next(0, 100) < _fillPercecnt) ? 1 : 0;
                    }
                    if(y >= _mapHeight - 3)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }

        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighborWall = GetWallCount(x, y);

                    if (neighborWall > CountWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if(neighborWall < CountWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }

        private int GetWallCount(int x, int y)
        {
            int wallCount = 0;

            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            wallCount += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }
            return wallCount;
        }

        private void DrawTiles()
        {
            if (_map == null)
                return;
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    var positionTile = new Vector3Int(-_mapWidth / 2 + x, -_mapWidth / 2 + y, 0);

                    if(_map[x,y] == 1)
                    {
                        _tileMap.SetTile(positionTile, _groundTile);
                    }
                }
            }
        }
    }
}