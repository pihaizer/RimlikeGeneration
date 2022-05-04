using UnityEngine;
using UnityEngine.Tilemaps;

namespace RimlikeGeneration
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Tilemap _groundTilemap;
        [SerializeField] private Tilemap _wallsTilemap;
        [SerializeField] private Tilemap _itemsTilemap;

        public Vector2Int Size { get; private set; } = new(200, 200);

        public void SetGroundTile(int x, int y, GroundTile tile)
        {
            _groundTilemap.SetTile(new Vector3Int(x, y), tile.Tile);
            
        }
    }
}