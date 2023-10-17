using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Grid myGrid;
    public int objectif;
    public GameObject EndScreen;
    public GameObject PauseScreen;
    public class Undo
    {
        public GameObject Player;
        public GameObject Box;
        public Vector3 PlayerMove;
        public Vector3 BoxMove;
        public void LoadSave()
        {
            Player.transform.position = PlayerMove;
            if (!Box.IsUnityNull())
            {
                Box.GetComponent<BoxScript>().ValidMove(BoxMove - Box.transform.position);
                Box.transform.position = BoxMove;
            }
        }
    }

    public List<Undo> undoList = new List<Undo>();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        objectif = myGrid.gridInfo.boxNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        { 
            LoadLastMove();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if (objectif == 0)
        {
            EndScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void SaveMove(GameObject player, GameObject box = null, Vector3 movement = new Vector3())
    {
        Undo save = new Undo();
        save.Player = player;
        save.PlayerMove = player.transform.position;
        save.Box = box;
        if (box != null)
        {
            
            save.BoxMove = box.transform.position - movement;
        }
        undoList.Add(save);
    }
    public void LoadLastMove()
    {
        if (undoList.Count > 0)
        {

            undoList[undoList.Count - 1].LoadSave();
            undoList.Remove(undoList[undoList.Count - 1]);

        }
    }
}

