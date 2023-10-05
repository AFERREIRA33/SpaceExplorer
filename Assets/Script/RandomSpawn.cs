using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject asteroid;

    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(spawnAsteroid());
    }
    IEnumerator spawnAsteroid()
    {
        yield return new WaitForSeconds(1);
        Vector2 spawnPos = new Vector2(Random.Range(-10, 10), transform.position.y);
        Instantiate(asteroid, spawnPos, Quaternion.identity);
        spawnPos = new Vector2(Random.Range(-10, 10), transform.position.y);
        Instantiate(asteroid, spawnPos, Quaternion.identity); 
        spawnPos = new Vector2(Random.Range(-10, 10), transform.position.y);
        Instantiate(asteroid, spawnPos, Quaternion.identity);
        StartCoroutine(spawnAsteroid());
    }
}
