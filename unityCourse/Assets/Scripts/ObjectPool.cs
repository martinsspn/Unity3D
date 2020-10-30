using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    //public Queue<GameObject> pooledObjects = new Queue<GameObject>();
    public Dictionary<string, Queue<GameObject>> pooledObjects = new Dictionary<string, Queue<GameObject>>(); 
    //[SerializeField] public GameObject objectToPool;


    // Start is called before the first frame update
    void Awake()
    {
        SharedInstance = this;
        Queue<GameObject> enemies = new Queue<GameObject>();
        Queue<GameObject> bullets = new Queue<GameObject>();
        pooledObjects.Add("Enemy", enemies);
        pooledObjects.Add("Bullet", bullets);
    }

    void AddObjects(string tag, GameObject objectToPool)
    { 
        Queue<GameObject> objPool = new Queue<GameObject>();
        var obj = GameObject.Instantiate(objectToPool);
        obj.SetActive(false);
        objPool.Enqueue(obj);
        //Debug.Log(obj.tag);
        if(pooledObjects.ContainsKey(tag))
        {
            pooledObjects[tag].Enqueue(obj);
        }
        else
        {
            pooledObjects.Add(tag, objPool);    
        }
    }
    
    public GameObject GetPooledObject(string tag, GameObject objectToPool)
    {
        if(!pooledObjects.ContainsKey(tag)){
            AddObjects(tag, objectToPool);
        }
        else
        {
            if(pooledObjects[tag].Count == 0)
            {
                AddObjects(tag, objectToPool);
            }
        }
        return pooledObjects[tag].Dequeue();
        
        /*for(int i =0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                GameObject aux = pooledObjects[i];
                pooledObjects.Remove(pooledObjects[i]);
                return aux;
            }
        }
        return null;
        */
    }

    public void ReturnToPool(GameObject objToPool)
    {
        objToPool.SetActive(false);
        pooledObjects[objToPool.tag].Enqueue(objToPool);
    }
}