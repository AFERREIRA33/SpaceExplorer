using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Vector3 movement;
    public Grid myGrid;
    public GameObject[] walls;
    public GameObject[] boxs;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        movement.z = 0;

    }
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetButtonDown("Vertical"))
            {
                movement.y = Input.GetAxis("Vertical") > 0 ? 1 : -1;
                if (ValidMove(movement))
                {
                    transform.position += movement * Time.timeScale;
                }
                movement = Vector3.zero;

            }
            if (Input.GetButtonDown("Horizontal"))
            {
                movement.x = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
                if (ValidMove(movement))
                {
                    transform.position += movement * Time.timeScale;
                }
                movement = Vector3.zero;
            }
        }
    }
    private bool ValidMove(Vector3 movement)
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        boxs = GameObject.FindGameObjectsWithTag("Box");
        bool validMove = true;
        bool isSave = false;
        foreach (GameObject wall in walls)
        {
            
            if (wall.transform.position.x == transform.position.x + movement.x && wall.transform.position.y == transform.position.y + movement.y)
            {
                validMove = false;
                break;
            }
        }
        if (validMove)
        {
            foreach (GameObject box in boxs)
            {
                if (box.transform.position.x == transform.position.x + movement.x && box.transform.position.y == transform.position.y + movement.y)
                {
                    if(!box.GetComponent<BoxScript>().ValidMove(movement))
                    {
                        validMove = false;
                        break;
                    } else
                    {
                        gameManager.SaveMove(transform.GameObject(), box, movement);
                        isSave = true;
                        break;
                    }
                }
            }
        }
        if (!isSave)
        {
            gameManager.SaveMove(transform.GameObject());
        }
        return validMove;
    }
}
