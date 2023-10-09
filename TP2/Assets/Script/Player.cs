using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10;
    Rigidbody2D rb;
    private bool collisionOccurred;
    private int Score = 0;
    public TextMeshProUGUI displayScore;
    public TextMeshProUGUI displayScoreEndScreen;
    public Canvas endScreen;
    public Canvas gameHUD;
    private int jumpNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (collisionOccurred || jumpNum <2))
        {
            jumpNum++;
            Vector2 up = new Vector2(rb.velocity.x, jumpForce);
            rb.AddForce(up, ForceMode2D.Impulse); 
        }
        if (transform.position.y < -5) 
        {
            displayScoreEndScreen.text = Score.ToString();
            gameHUD.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionOccurred = true;
        Score++;
        displayScore.text = Score.ToString();
        jumpNum = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionOccurred = false;
    }


}
