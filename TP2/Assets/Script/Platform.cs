using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector2 targetPosition;
    public float speed = 5f;
    void Start()
    {
        targetPosition = new Vector2(-13, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (-12 > transform.position.x  )
        {
            Destroy( gameObject );
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed* Time.deltaTime);
    }
}
