using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RimlikeGeneration
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Tilemap _groundTilemap;
        [SerializeField] private Tilemap _wallsTilemap;
        [SerializeField] private Tilemap _itemsTilemap;

        public Vector2Int Size;
        private MapTile[,] _tiles;

        public void Clear()
        {
            _groundTilemap.ClearAllTiles();
            _wallsTilemap.ClearAllTiles();
            _itemsTilemap.ClearAllTiles();

            _tiles = new MapTile[Size.x, Size.y];
        }

        public void SetGroundTile(int x, int y, GroundTile tile)
        {
            if (tile == null) return;
            _groundTilemap.SetTile(new Vector3Int(x, y), tile.Tile);
        }

        public void SetWallTile(int x, int y, WallTile tile)
        {
            if (tile == null) return;
            _wallsTilemap.SetTile(new Vector3Int(x, y), tile.Tile);
        }

        public void SetGroundTileColor(int x, int y, Color color)
        {
            _groundTilemap.SetTileFlags(new Vector3Int(x, y), TileFlags.None);
            _groundTilemap.SetColor(new Vector3Int(x, y), color);
        }
    }
}