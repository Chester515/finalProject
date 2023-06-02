using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainProperties : MonoBehaviour
{

    public string name_ = "Name";

    public bool traversable = true;
    public int movementCost = 1;

    public bool clicked;

    private TerrainManager terrainManager;

    // Start is called before the first frame update
    void Start()
    {
        terrainManager = GameObject.Find("TerrainManager").GetComponent<TerrainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        terrainManager.recentlyClicked = this.gameObject;
    }
}
