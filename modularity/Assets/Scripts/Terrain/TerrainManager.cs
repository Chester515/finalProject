using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject[] terrainGrid;
    public TerrainProperties[] terrainProperties;


    public GameObject recentlyClicked;


    // Start is called before the first frame update
    void Start()
    {
        terrainGrid = SortTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private GameObject[] SortTerrain() {
        GameObject[] terrList = GameObject.FindGameObjectsWithTag("Terrain");
        int numTerrain = terrList.Length;
        GameObject[] terrainGrid = new GameObject[numTerrain];
        int gridSize = (int)Mathf.Sqrt(numTerrain);
        for (int i = 0; i < numTerrain; i++){
            GameObject terr = terrList[i];
            int index = (int) (terr.transform.position.x + terr.transform.position.z * gridSize);
            terrainGrid[index] = terr;
        }

        return terrainGrid;
    }
}
