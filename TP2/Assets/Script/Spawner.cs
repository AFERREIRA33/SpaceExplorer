using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;
    public float lastSpawnY;
    // Start is called before the first frame update
    private void Start()
    {
        lastSpawnY = player.transform.position.y;
        StartCoroutine(spawnPlatform());
    }
    IEnumerator spawnPlatform()
    {
        
        yield return new WaitForSeconds(2);
        Vector2 spawnPos = new Vector2(transform.position.x, Random.Range(-5, Mathf.Clamp(lastSpawnY+4,-5, 3)));
        Debug.Log(spawnPos);
        Instantiate(platform, spawnPos, Quaternion.identity);
        lastSpawnY = spawnPos.y;
        StartCoroutine(spawnPlatform());

    }
}
