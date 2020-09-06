using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//O script você pode pôr em qualquer lugar da cena, desde que esteja ativo
//Não se esqueça de nomear seu script para "Image", ou se for mudar, mude também no script.
public class Parallax : MonoBehaviour
{
    //Coloque a referência de background aqui.
    public RawImage image;
    //Mude a velocidade que sua imagem irá "andar".
    public float speed;

    private void FixedUpdate()
    {
        image.uvRect = new Rect(image.uvRect.x + speed * Time.deltaTime, image.uvRect.y, image.uvRect.width, image.uvRect.height);
    }
}