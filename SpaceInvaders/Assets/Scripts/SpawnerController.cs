using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public float minX;
    public float maxX;
    private bool increaseDifficult = true;
    public float timeSpawn;
    private bool spawned;
    public float mimTime;
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!spawned)
            StartCoroutine(TimedSpawn(timeSpawn + mimTime));

            //InvokeRepeating("Spawn", timeSpawn, timeSpawn);
    }

    void Update()
    {
        if(increaseDifficult == true)
        {
            if (PlayerScore.playerScore == 20 || PlayerScore.playerScore == 50 || PlayerScore.playerScore == 100)
            {
                timeSpawn /= 1.3f;
                increaseDifficult = false;
            }
        }
        if(PlayerScore.playerScore == 21 || PlayerScore.playerScore == 51 || PlayerScore.playerScore == 101)
        {
            increaseDifficult = true;
        }
    }

    public void Spawn()
    {
        //GameObject ob = GameObject.Instantiate(enemy) as GameObject;
        Vector2 newPos = new Vector2(Random.Range(minX, maxX), 7f);
        //ob.transform.position = newPos;
        GameObject ob = ObjectPool.SharedInstance.GetPooledObject(obj.tag, obj);
        if (ob != null)
        {
            ob.transform.position = newPos;
            ob.SetActive(true);
        }
        
    }

    IEnumerator TimedSpawn(float t)
    {
        spawned = true;
        yield return new WaitForSeconds(t);
        Spawn();
        spawned = false;
    }
}
