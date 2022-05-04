using Sirenix.OdinInspector;
using UnityEngine;

namespace RimlikeGeneration
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private string _seed;

        [SerializeField] private GroundTile _dirtGroundTile;
        [SerializeField] private GroundTile _grassGroundTile;
        [SerializeField] private GroundTile _stoneGroundTile;

        [SerializeField] private Map _map;

        private const int _heightOffset = 100;
        private const int _humidityOffset = 200;

        private int SeedOffset => _seed.GetHashCode();

        [Button]
        private void GenerateMap()
        {
            for (int x = 0; x < _map.Size.x; x++)
            {
                for (int y = 0; y < _map.Size.y; y++)
                {
                    _map.SetGroundTile(x, y, GenerateTile(x, y));
                }
            }
        }

        private GroundTile GenerateTile(int x, int y)
        {
            float height = GetHeight(x, y);

            if (height > 0.4f) return _stoneGroundTile;

            float humidity = GetHumidity(x, y);
            return humidity > 0.5f ? _grassGroundTile : _dirtGroundTile;
        }

        private float GetHeight(int x, int y) =>
            Mathf.PerlinNoise(SeedOffset + _heightOffset + x, SeedOffset + _heightOffset + y);

        private float GetHumidity(int x, int y) =>
            Mathf.PerlinNoise(SeedOffset + _humidityOffset + x, SeedOffset + _humidityOffset + y);
    }
}