using UnityEngine;
using UnityEngine.Tilemaps;

namespace RimlikeGeneration
{
    [CreateAssetMenu(fileName = "Wall Tile", menuName = "Scriptable Objects/Wall Tile")]
    public class WallTile : ScriptableObject
    {
        [SerializeField] private Tile _tile;

        public Tile Tile => _tile;
    }
}