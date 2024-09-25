using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject blockPrefab;  // Assign your Block prefab here
    public int chunkWidth = 16;  // Width of the chunk (X direction)
    public int chunkLength = 16;  // Length of the chunk (Z direction)
    public int chunkHeight = 384;  // Height of the chunk (Y direction)
    public int maxSurfaceHeight = 64;  // Max height for the surface terrain
    public float noiseScale = 0.05f;  // Controls terrain smoothness
    private float seed;  // Random seed for noise variation

    void Start()
    {
        // Generate a random seed so that each chunk is different
        seed = Random.Range(0f, 1000f);
        GenerateChunk();
    }

    void GenerateChunk()
    {
        for (int x = 0; x < chunkWidth; x++)
        {
            for (int z = 0; z < chunkLength; z++)
            {
                // Calculate height for the terrain surface using Perlin noise
                int surfaceHeight = Mathf.FloorToInt(PerlinNoise(x, z) * maxSurfaceHeight);

                // Generate blocks from the bottom of the chunk (Y = 0) up to the surface height
                for (int y = 0; y < chunkHeight; y++)
                {
                    // Below the surface, generate solid blocks
                    if (y <= surfaceHeight)
                    {
                        Vector3 position = new Vector3(x, y, z);
                        Instantiate(blockPrefab, position, Quaternion.identity);
                    }
                }
            }
        }
    }

    float PerlinNoise(int x, int z)
    {
        // Use seed and noiseScale to generate smooth terrain variation
        return Mathf.PerlinNoise((x + seed) * noiseScale, (z + seed) * noiseScale);
    }
}
