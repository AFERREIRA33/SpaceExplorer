using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 screenBounds;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    float rotation;
    public PolygonCollider2D polygonCollider;
    public int life = 3;
    public Canvas EndScreen;
    public TextMeshProUGUI loose;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {

        movement.y = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        if (rotation != 0)
        {
            rb.rotation = Mathf.Clamp(rb.rotation, -60, 60);
            rb.MoveRotation(rb.rotation - rotation * 50 * moveSpeed * Time.fixedDeltaTime);
        }
        if(life < 0)
        {
            Time.timeScale = 0f;
            loose.text = "You loose skill issue !";
            EndScreen.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }
        if (transform.position.x <= screenBounds.x * -1)
        {
            transform.position = new Vector2(screenBounds.x * -1, transform.position.y);
        }
        if (transform.position.y >= screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y);
        }
        if (transform.position.y <= screenBounds.y * -1)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y * -1);
        }
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Finish")
        {
            Time.timeScale = 0f;
            loose.text = "You win GGWP !";
            EndScreen.gameObject.SetActive(true);
        } else
        {
            life--;
        }
    }
}
