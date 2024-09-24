using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject blockPrefab; // Drag your Block prefab here
    public int width = 10;  // Number of blocks in X direction
    public int depth = 10;  // Number of blocks in Z direction
    public int height = 5;  // Maximum height of terrain

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                int yHeight = Mathf.FloorToInt(PerlinNoise(x, z) * height); // Use Perlin Noise for height
                for (int y = 0; y <= yHeight; y++)
                {
                    Vector3 position = new Vector3(x, y, z);
                    Instantiate(blockPrefab, position, Quaternion.identity);
                }
            }
        }
    }

    float PerlinNoise(int x, int z)
    {
        float scale = 0.1f;  // Adjust the scale to modify terrain frequency
        return Mathf.PerlinNoise(x * scale, z * scale);
    }
}
