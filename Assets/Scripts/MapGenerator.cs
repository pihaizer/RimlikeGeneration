using Sirenix.OdinInspector;
using UnityEngine;

namespace RimlikeGeneration
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private string _seed;

        [SerializeField, Range(0, 100)] private float _heightNoiseScale;
        [SerializeField, Range(0, 100)] private float _humidityNoiseScale;

        [SerializeField, Range(0, 1f)] private float _stoneHeightRequirement;
        [SerializeField, Range(0, 1f)] private float _grassHumidityRequirement;

        [SerializeField] private GroundTile _dirtGroundTile;
        [SerializeField] private GroundTile _grassGroundTile;
        [SerializeField] private GroundTile _stoneGroundTile;

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
                    _map.SetGroundTile(x, y, GenerateTile(height, humidity));
                    // _map.SetGroundTileColor(x, y, new Color(0, humidity, 0));
                }
            }
        }

        private GroundTile GenerateTile(float height, float humidity)
        {

            if (height > _stoneHeightRequirement) return _stoneGroundTile;
            return humidity > _grassHumidityRequirement ? _grassGroundTile : _dirtGroundTile;
        }

        private float GetHeight(int x, int y)
        {
            float xOffset = (SeedOffset + _heightOffset + x) % 100000 * _heightNoiseScale;
            float yOffset = (SeedOffset + _heightOffset + y) % 100000 * _heightNoiseScale;
            return Mathf.PerlinNoise(xOffset, yOffset);
        }

        private float GetHumidity(int x, int y)
        {
            float xOffset = (SeedOffset + _humidityOffset + x) % 100000 * _heightNoiseScale;
            float yOffset = (SeedOffset + _humidityOffset + y) % 100000 * _heightNoiseScale;
            return Mathf.PerlinNoise(xOffset, yOffset);
        }
    }
}