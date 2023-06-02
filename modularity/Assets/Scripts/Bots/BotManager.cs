using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{

    private TerrainManager terrainManager;

    public GameObject selectedBot;


    public GameObject[] bots;
    // Start is called before the first frame update
    void Start()
    {
        terrainManager = GameObject.Find("TerrainManager").GetComponent<TerrainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedBot != null) {

        }
    }
}
