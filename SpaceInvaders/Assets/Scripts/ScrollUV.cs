using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    
    public float scrollerSpeed;
    void Update()
    {
        MeshRenderer rm = GetComponent<MeshRenderer>();
        Material mat = rm.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime * scrollerSpeed;
        mat.mainTextureOffset = offset;
    }
}
