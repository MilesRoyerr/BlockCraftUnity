using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject blockPrefab;  
    public int chunkWidth = 16;    
    public int chunkLength = 16;   
    public int chunkHeight = 384;   // Height of the chunk (Y direction)
    public int maxSurfaceHeight = 64; // Maximum height for surface terrain
    public float noiseScale = 0.05f;  // Controls the terrain smoothness

    private float seed; // Random seed for noise variation

    void Start()
    {
        seed = Random.Range(0f, 1000f); // Random seed for chunk variety
        GenerateChunk();
    }

    void GenerateChunk()
    {
        for (int x = 0; x < chunkWidth; x++)
        {
            for (int z = 0; z < chunkLength; z++)
            {
                int surfaceHeight = Mathf.FloorToInt(PerlinNoise(x, z) * maxSurfaceHeight);

                // Generate blocks up to the surfaceHeight only
                for (int y = 0; y <= surfaceHeight; y++)
                {
                    Vector3 position = new Vector3(x, y, z);
                    Instantiate(blockPrefab, position, Quaternion.identity);
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
