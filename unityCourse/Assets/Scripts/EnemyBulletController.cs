using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    private AudioSource audio;
    public static bool shotEnemyBullet = false;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        audio = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -7)
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        
        if(shotEnemyBullet)
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            shotEnemyBullet = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerLife.playerLife -= 10f;
            if(PlayerLife.playerLife <= 0)
            {
                Destroy(other.gameObject);
                GameOver.isPlayerDead = true;
            }
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }
}
