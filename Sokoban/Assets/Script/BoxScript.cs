using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject[] goals;
    public GameObject[] boxs;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public bool ValidMove(Vector3 movement)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        boxs = GameObject.FindGameObjectsWithTag("Box");
        goals = GameObject.FindGameObjectsWithTag("Goal");
        bool validMove = true;
        foreach (GameObject wall in walls)
        {

            if (wall.transform.position.x == transform.position.x + movement.x && wall.transform.position.y == transform.position.y + movement.y)
            {
                validMove = false;
                break;
            }
        }
        foreach (GameObject box in boxs)
        {

            if (box.transform.position.x == transform.position.x + movement.x && box.transform.position.y == transform.position.y + movement.y)
            {
                validMove = false;
                break;
            }
        }
        
        if (validMove)
        {
            foreach (GameObject goal in goals)
            {
                if (goal.transform.position.x == transform.position.x && goal.transform.position.y == transform.position.y)
                {
                    gameManager.objectif++;
                }
                if (goal.transform.position.x == transform.position.x + movement.x && goal.transform.position.y == transform.position.y + movement.y)
                {
                    gameManager.objectif--;
                }
            }
            transform.position += movement;
        }
        return validMove;
    }
}

