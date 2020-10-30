using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static float playerLife = 100f;
    public Texture blood, Contorno;
    public float maxLife = 100f;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = maxLife;        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLife >= maxLife)
        {
            playerLife = maxLife;
        }
        else if (playerLife <= 0)
        {
            playerLife = 0;
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture (new Rect (Screen.width / 19, Screen.height / 28, Screen.width / 4.9f/maxLife*playerLife, Screen.height / 30), blood);
        GUI.DrawTexture (new Rect (Screen.width / 50, Screen.height / 50, Screen.width / 4f, Screen.height / 15), Contorno);
    }
}
