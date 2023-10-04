using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 screenBounds;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {

        movement.y = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        Debug.Log(rb.rotation);
        if (rotation != 0 )
        {
            rb.rotation = Mathf.Clamp(rb.rotation, -60, 60);
            rb.MoveRotation(rb.rotation - rotation * 50 * moveSpeed * Time.fixedDeltaTime);
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
        /*Vector2 objPos = transform.position;
        objPos.x = Mathf.Clamp(objPos.x + movement.x, screenBounds.x, screenBounds.x * -1) - objPos.x;
        objPos.y = Mathf.Clamp(objPos.y + movement.y, screenBounds.y, screenBounds.y * -1) - objPos.y;
        transform.Translate(objPos * moveSpeed * Time.fixedDeltaTime);*/
    }
}