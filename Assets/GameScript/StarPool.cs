using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPool : MonoBehaviour
{
    public static StarPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;


    Queue<GameObject> poolingObjQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjQueue.Enqueue(CreateNewObject());
        }
    }

    GameObject CreateNewObject()
    {
        GameObject newObj = Instantiate(poolingObjectPrefab);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static GameObject GetGameObject()
    {
        if (Instance.poolingObjQueue.Count > 0)
        {
            var obj = Instance.poolingObjQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            return obj;
        }
        else
        {
            var obj = Instance.CreateNewObject();
            obj.SetActive(true);
            obj.transform.SetParent(null);
            return obj;
        }
    }

    public static void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjQueue.Enqueue(obj);
    }

}
