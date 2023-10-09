using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -5)
        {
            Destroy(transform.gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(transform.gameObject);
    }
}
