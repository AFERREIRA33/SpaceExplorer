using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    float rotation;
    // Start is called before the first frame update
    void Start()
    {

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
        /*else if (rb.rotation > 60f)
        {
            rb.SetRotation(60f);
        } else if (rb.rotation < -60f)   && rb.rotation <= 60f && rb.rotation >= -60f
        {
            rb.SetRotation(-60f);
        }*/
    }

    private void FixedUpdate()
    {
        
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
        //Vector2 rbPos = new Vector2(rb.position.x, rb.position.y);
        //rb(rbPos + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
