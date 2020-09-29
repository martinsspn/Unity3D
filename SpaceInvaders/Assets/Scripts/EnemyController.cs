using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemy;
    public float speed;
    public float next_spawn_time;
    public GameObject shot;
    public float fireRate = 0.997f;
    public static float life = 3;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform> ();
        next_spawn_time = Time.time+5.0f;
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.position += Vector3.up * speed * -1;
        if(enemy.position.y <= -7f){
            //Destroy (gameObject);
            //ObjectPool.SharedInstance.returnToPool(gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            GameOver.isPlayerDead = true;
        }

        if (Random.value > fireRate)
        {
            Instantiate(shot, enemy.position, enemy.rotation);
        }
    }

/*
    void Update(){
        if(Time.time > next_spawn_time)
     {
         //do stuff here (like instantiate)
        //Instantiate(enemy, Vector3.right * 2f, enemy.rotation);
        GameObject enemy = ObjectPool.SharedInstance.GetPooledObject("Enemy");
        Debug.Log("Entrou aqui");
        if (enemy != null)
        {
            enemy.transform.position = Vector3.right * 2f;
            enemy.transform.rotation = enemy.transform.rotation;
            enemy.SetActive(true);
        }
        //increment next_spawn_time
        next_spawn_time += 5.0f;
     }
    }
*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerLife.playerLife -= 20;
            if(PlayerLife.playerLife <= 0)
            {
                Destroy(other.gameObject);
                GameOver.isPlayerDead = true;
            }
            //Destroy (gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            
        }
    }
}
