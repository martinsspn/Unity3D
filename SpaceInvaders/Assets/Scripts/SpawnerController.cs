using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float minX;
    public float maxX;
    
    public float timeSpawn;
    private bool spawned;
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!spawned)
            StartCoroutine(TimedSpawn(timeSpawn));

            //InvokeRepeating("Spawn", timeSpawn, timeSpawn);
    }

    public void Spawn()
    {
        GameObject ob = GameObject.Instantiate(enemy) as GameObject;
        Vector2 newPos = new Vector2(Random.Range(minX, maxX), 7f);
        ob.transform.position = newPos;
    }
      
    IEnumerator TimedSpawn(float t)
    {
        spawned = true;
        yield return new WaitForSeconds(t);
        Spawn();
        spawned = false;
    }
}
