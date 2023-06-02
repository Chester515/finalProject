using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class BotBehavior : MonoBehaviour
{
    public GameObject[] grid;
    public List<Vector2> legalMoves;

    public bool selected;

    private LineRenderer lineRenderer;

    private BotManager botManager;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        botManager = GameObject.Find("BotManager").GetComponent<BotManager>();
    }

    void Update() {
        legalMoves = new List<Vector2>();
        if (grid.Length <= 0)
        {
            grid = GameObject.Find("TerrainManager").GetComponent<TerrainManager>().terrainGrid;
        }
        CheckLine((int)Mathf.Floor(transform.position.x),(int)Mathf.Floor(transform.position.z),1,0,2);

        if (selected) {
            ShowMoves();
        } else {
            lineRenderer.positionCount = 0;
        }
    }

    void CheckLine(int x, int y, int xOffset, int yOffset, int maxRange)
    {
        int moveX = x;
        int moveY = y;
        for (int i = 0; i <= maxRange; i++) 
        {
            
            if (moveX < Mathf.Sqrt(grid.Length) && moveX >= 0 && moveY < Mathf.Sqrt(grid.Length) && moveY >= 0)
            {
                if (grid[(int)(moveX+moveY*Mathf.Sqrt(grid.Length))].GetComponent<TerrainProperties>().traversable) 
                {
                    legalMoves.Add(new Vector2(moveX,moveY));
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
            moveX += xOffset;
            moveY += yOffset;
        }
    }

    void ShowMoves() {
        Debug.Log("Moves");

        lineRenderer.positionCount = legalMoves.Count;
        var points = new Vector3[legalMoves.Count];
        for (int i = 0; i < legalMoves.Count; i++) {
            points[i] = new Vector3(legalMoves[i].x, transform.position.y, legalMoves[i].y);
        }
        lineRenderer.SetPositions(points);
    }

    void OnMouseDown() {
        selected = !selected;

        if (selected) {
            botManager.selectedBot = this.gameObject;
        } else {
            botManager.selectedBot = null;
        }
    }
}
