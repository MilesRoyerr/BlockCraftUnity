using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject blockPrefab;  
    public int chunkWidth = 16;    
    public int chunkLength = 16;   
    public int chunkHeight = 384;   
    public int maxSurfaceHeight = 64; 
    public float noiseScale = 0.05f;  

    private float seed; 

    void Start()
    {
        seed = Random.Range(0f, 1000f); 
        GenerateChunk();
    }

    void GenerateChunk()
    {
        for (int x = 0; x < chunkWidth; x++)
        {
            for (int z = 0; z < chunkLength; z++)
            {
                int surfaceHeight = Mathf.FloorToInt(PerlinNoise(x, z) * maxSurfaceHeight);

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
        
        return Mathf.PerlinNoise((x + seed) * noiseScale, (z + seed) * noiseScale);
    }
}
