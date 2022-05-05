using Sirenix.OdinInspector;
using UnityEngine;

namespace RimlikeGeneration
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private string _seed;

        [SerializeField] private float _heightNoiseScale;
        [SerializeField] private float _humidityNoiseScale;
        
        [SerializeField] private float _heightNoiseFactor = 1;
        [SerializeField] private float _humidityNoiseFactor = 1;

        [SerializeField, Range(0, 1f)] private float _stoneHeightRequirement;
        [SerializeField, Range(0, 1f)] private float _stoneWallHeightRequirement;
        [SerializeField, Range(0, 1f)] private float _grassHumidityRequirement;

        [SerializeField] private GroundTile _dirtGroundTile;
        [SerializeField] private GroundTile _grassGroundTile;
        [SerializeField] private GroundTile _stoneGroundTile;

        [SerializeField] private WallTile _wallTile;

        [SerializeField] private Map _map;

        private const int _heightOffset = 100;
        private const int _humidityOffset = 200;

        private int SeedOffset => _seed.GetHashCode();

        [Button]
        private void GenerateSeed()
        {
            _seed = Random.Range(0, int.MaxValue).ToString();
        }

        [Button]
        private void GenerateMap()
        {
            _map.Clear();

            for (int x = 0; x < _map.Size.x; x++)
            {
                for (int y = 0; y < _map.Size.y; y++)
                {
                    float height = GetHeight(x, y);
                    float humidity = GetHumidity(x, y);
                    _map.SetGroundTile(x, y, GenerateGroundTile(height, humidity));
                    _map.SetWallTile(x, y, GenerateWallTile(height, humidity));
                    // _map.SetGroundTileColor(x, y, new Color(0, humidity, 0));
                }
            }
        }

        private GroundTile GenerateGroundTile(float height, float humidity)
        {
            if (height > _stoneHeightRequirement) return _stoneGroundTile;
            return humidity > _grassHumidityRequirement ? _grassGroundTile : _dirtGroundTile;
        }

        private WallTile GenerateWallTile(float height, float humidity)
        {
            return height > _stoneWallHeightRequirement ? _wallTile : null;
        }

        private float GetHeight(int x, int y)
        {
            float xOffset = (SeedOffset + _heightOffset + x) % 100000 * _heightNoiseScale;
            float yOffset = (SeedOffset + _heightOffset + y) % 100000 * _heightNoiseScale;
            return Mathf.Pow(Mathf.PerlinNoise(xOffset, yOffset), _heightNoiseFactor);
        }

        private float GetHumidity(int x, int y)
        {
            float xOffset = (SeedOffset + _humidityOffset + x) % 100000 * _heightNoiseScale;
            float yOffset = (SeedOffset + _humidityOffset + y) % 100000 * _heightNoiseScale;
            return Mathf.Pow(Mathf.PerlinNoise(xOffset, yOffset), _humidityNoiseFactor);
        }
    }
}