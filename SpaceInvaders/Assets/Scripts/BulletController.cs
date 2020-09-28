using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
    }
    

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
            //ObjectPool.SharedInstance.returnToPool(gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            //Destroy (gameObject);
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            EnemyController.life -= 1;
            if(EnemyController.life <= 0)
            {
                ObjectPool.SharedInstance.ReturnToPool(other.gameObject);
                PlayerScore.playerScore += 1;
                EnemyController.life = 3;
            }
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }
}
