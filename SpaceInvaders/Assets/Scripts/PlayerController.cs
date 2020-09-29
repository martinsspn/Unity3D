using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
	private Transform player;
	public float speed;
	public float maxBound, minBound, maxUp, minDown;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private AudioSource AudioDestroyPlayer;
    public static bool DestroyPlayer;

    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform> ();
        AudioDestroyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis ("Horizontal");
        float v = Input.GetAxis ("Vertical");
        if (player.position.x < minBound && h < 0 )
        	h = 0;
        else if (player.position.x > maxBound && h > 0)
        	h = 0;

        player.position += Vector3.right * h * speed;
        
        if (player.position.y <= maxUp)
            player.position += Vector3.up * v * speed;
    	else
            player.position += Vector3.up * -1f * speed;

        if (player.position.y >= minDown)
            player.position += Vector3.up * v * speed;
        else
            player.position += Vector3.up * 1f * speed;
    }

    void Update(){
        if(Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            BulletController.bulletSound = true;
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject("Bullet", shot);
        if (bullet != null)
        {
            bullet.transform.position = shotSpawn.transform.position;
            bullet.transform.rotation = shotSpawn.transform.rotation;
            bullet.SetActive(true);
        }
            
        }

        if (DestroyPlayer)
        {
            AudioSource.PlayClipAtPoint(AudioDestroyPlayer.clip, transform.position);
            DestroyPlayer = false;
        }
    }
}
