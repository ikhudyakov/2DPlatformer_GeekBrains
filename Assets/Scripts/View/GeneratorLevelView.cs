using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC
{
    public class GeneratorLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapWidth;
        [SerializeField] private int _mapHeight;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _factorSmooth;
        [SerializeField] [Range(0, 100)] private int _fillPercecnt;

        public Tilemap TileMap { get => _tileMap; set => _tileMap = value; }
        public Tile GroundTile { get => _groundTile; set => _groundTile = value; }
        public int MapWidth { get => _mapWidth; set => _mapWidth = value; }
        public int MapHeight { get => _mapHeight; set => _mapHeight = value; }
        public bool Borders { get => _borders; set => _borders = value; }
        public int FactorSmooth { get => _factorSmooth; set => _factorSmooth = value; }
        public int FillPercecnt { get => _fillPercecnt; set => _fillPercecnt = value; }
    }
}