using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class EnemyController : MonoBehaviour
{
    private Transform enemy;
    public float speed;
    public float next_spawn_time;
    public GameObject shot;
    public float fireRate = 0.997f;
    public static float life = 3;
    private AudioSource audioData;
    public static bool DestroyEnemy = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform> ();
        next_spawn_time = Time.time+5.0f;
        audioData = GetComponent<AudioSource>();
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
            
            //Instantiate(shot, enemy.position, enemy.rotation);
            GameObject enemyShot = ObjectPool.SharedInstance.GetPooledObject(shot.tag, shot);
            if (shot != null)
            {
                enemyShot.transform.position = enemy.transform.position;
                enemyShot.transform.rotation = enemy.transform.rotation;
                enemyShot.SetActive(true);
                EnemyBulletController.shotEnemyBullet = true;
            }
        }

        if (DestroyEnemy)
        {
            AudioSource.PlayClipAtPoint(audioData.clip, transform.position);
            DestroyEnemy = false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            PlayerLife.playerLife -= 20;
            if(PlayerLife.playerLife <= 0)
            {
                PlayerController.DestroyPlayer = true;
                Destroy(other.gameObject, 1f);
                GameOver.isPlayerDead = true;
                
            }
            else
            {

            }
            //Destroy (gameObject);
            AudioSource.PlayClipAtPoint(audioData.clip, transform.position);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            
        }
    }
}
