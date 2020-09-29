using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitController : MonoBehaviour
{
    private Transform medKit;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        medKit = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        medKit.position += Vector3.up * speed * -1;
        if(medKit.position.y <= -9f){
            //Destroy (gameObject);
            //ObjectPool.SharedInstance.returnToPool(gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerLife.playerLife += 50;
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }
}
