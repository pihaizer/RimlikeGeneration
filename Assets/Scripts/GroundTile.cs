
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RimlikeGeneration
{
    [CreateAssetMenu(fileName = "Ground Tile", menuName = "Scriptable Objects/Ground Tile")]
    public class GroundTile : ScriptableObject
    {
        [SerializeField] private Tile _tile;

        public Tile Tile => _tile;
    }    
}
