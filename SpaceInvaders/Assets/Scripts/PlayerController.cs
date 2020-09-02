using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
	private Transform player;
	public float speed;
	public float maxBound, minBound, maxUp, minDown;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis ("Horizontal");
        float v = Input.GetAxis ("Vertical");
        if (player.position.x < minBound && h < 0 )
        	h = 0;
        else if (player.position.x > maxBound && h > 0)
        	h = 0;

        player.position += Vector3.right * h * speed;
        
        if (player.position.y > minDown)
            player.position = ();
        	

        
    }
}
