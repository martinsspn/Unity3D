using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    private AudioSource audio;
    public static bool bulletSound = false;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        audio = GetComponent<AudioSource> ();
    }
    

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            
        if(bulletSound)
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            bulletSound = false;
        }
    }


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            EnemyController.life -= 1;
            if(EnemyController.life <= 0)
            {
                EnemyController.DestroyEnemy = true;
                ObjectPool.SharedInstance.ReturnToPool(other.gameObject);
                PlayerScore.playerScore += 1;
                EnemyController.life = 3;
            }
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }
}
