using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject blockPrefab;  // Assign your Block prefab here
    public int width = 10;  // X size of terrain
    public int depth = 10;  // Z size of terrain
    public int maxHeight = 20;  // Max height above ground level (surface)
    public int baseDepth = 60;  // Base layer depth (underground)
    public float noiseScale = 0.1f;  // Controls terrain smoothness
    public int randomFactor = 2;  // Extra randomness added to Perlin noise
    private float seed;  // Random seed for noise variation

    void Start()
    {
        // Generate a random seed so that each terrain is different
        seed = Random.Range(0f, 100f);
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                // Add randomness to Perlin noise input
                int perlinHeight = Mathf.FloorToInt(PerlinNoise(x, z) * maxHeight);

                // Add random variation on top of Perlin noise
                int randomHeight = Random.Range(0, randomFactor);

                // Total height with randomness
                int surfaceHeight = Mathf.Clamp(perlinHeight + randomHeight, 0, maxHeight);

                // First, generate the base depth (underground)
                for (int y = 0; y < baseDepth; y++)
                {
                    Vector3 position = new Vector3(x, y, z);
                    Instantiate(blockPrefab, position, Quaternion.identity);
                }

                // Then, generate the terrain on top of the base
                for (int y = baseDepth; y <= baseDepth + surfaceHeight; y++)
                {
                    Vector3 position = new Vector3(x, y, z);
                    Instantiate(blockPrefab, position, Quaternion.identity);
                }
            }
        }
    }

    float PerlinNoise(int x, int z)
    {
        // Add the seed to the Perlin noise input for randomness
        return Mathf.PerlinNoise((x + seed) * noiseScale, (z + seed) * noiseScale);
    }
}
