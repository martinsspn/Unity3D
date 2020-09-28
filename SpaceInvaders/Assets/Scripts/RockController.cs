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
            Destroy(other.gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            GameOver.isPlayerDead = true;
        }
        else
        {
            ObjectPool.SharedInstance.ReturnToPool(other.gameObject);
        }
    }
}
