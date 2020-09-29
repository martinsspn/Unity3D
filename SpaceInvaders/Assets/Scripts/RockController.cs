using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private Transform rock;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rock = GetComponent<Transform> ();
        
    }

    void FixedUpdate()
    {
        rock.position += Vector3.up * speed * -1;
        if(rock.position.y <= -9f){
            //Destroy (gameObject);
            //ObjectPool.SharedInstance.returnToPool(gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerLife.playerLife -= 50;
            if(PlayerLife.playerLife <= 0)
            {
                Destroy(other.gameObject);
                GameOver.isPlayerDead = true;
            }
            //Destroy (gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
        else
        {
            ObjectPool.SharedInstance.ReturnToPool(other.gameObject);
        }
    }
}
