using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Grid : MonoBehaviour
{
    public GameObject wall;
    public GameObject ground;
    public GameObject box;
    public GameObject goal;
    [System.Serializable]
    public class GridInfo
    {
        public int height;
        public int boxNumber;
    }
    
    public GridInfo gridInfo;
    public List<GameObject> grid;
    private List<int> ListBoxId = new List<int>();
    public GameObject FirstGround;
    public GameObject LastGround;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        GenerateBox();
    }

    public void GenerateGrid()
    {
        GameObject gr;
        for (int i = 0; i <= gridInfo.height+1; i++)
        {
            for(int j = 0; j <= gridInfo.height + 1; j++)
            {
                if (i == 0 || i == gridInfo.height+1 || j == 0 || j == gridInfo.height + 1)
                {
                    gr = Instantiate(wall, new Vector2(i - (gridInfo.height / 2)-1, j - (gridInfo.height / 2) - 1), Quaternion.identity);
                    gr.name = "wall_" + i + "_" + j;
                } else
                {
                    gr = Instantiate(ground, new Vector2(i - (gridInfo.height / 2)-1, j - (gridInfo.height / 2)-1), Quaternion.identity);
                    gr.name = "ground_" + (i - 1) + "_" + (j - 1);
                    if (i - 1 == 0 && j - 1 == 0)
                    {
                        FirstGround = gr;
                    } else if (j == gridInfo.height && i == gridInfo.height)
                    {
                        LastGround = gr;
                    }
                }
                grid.Add(gr);

            }
        }
    }

    public void GenerateBox()
    {
        int numBox = gridInfo.boxNumber;
        int numGoal = gridInfo.boxNumber;
        int spawnBox;
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        while (numBox >  0 || numGoal > 0) { 
            spawnBox = Random.Range(0, grounds.Length);
            
            if (!grounds[spawnBox].name.Contains("0") && !grounds[spawnBox].name.Contains((gridInfo.height-1).ToString()))
            {
                if (!(grounds[spawnBox].transform.position.x == 0 && grounds[spawnBox].transform.position.y == 0) && !ListBoxId.Contains(spawnBox) && numBox != 0)
                {
                    GameObject spawnedBox = Instantiate(box, grounds[spawnBox].transform.position, Quaternion.identity);
                    spawnedBox.transform.position += new Vector3(0,0,-1);
                    ListBoxId.Add(spawnBox);
                    numBox--;
                }
                if (!(grounds[spawnBox].transform.position.x == 0 && grounds[spawnBox].transform.position.y == 0) && !ListBoxId.Contains(spawnBox) && numGoal != 0)
                {
                    GameObject spawnedGoal = Instantiate(goal, grounds[spawnBox].transform.position, Quaternion.identity);
                    spawnedGoal.transform.position += new Vector3(0, 0, -1);
                    ListBoxId.Add(spawnBox);
                    numGoal--;
                }
            }
        }

    }
}
