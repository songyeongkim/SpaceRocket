using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    float moveSpeed;
    float disappearTime;
    public float disappearSpeed;
    public float minSpeed;
    public float maxSpeed;
    ObjectManager objectManager;
    float ranRotateSpeed;
    Vector3 ranRotateWay;


    private void Start()
    {
        disappearTime = Time.time + disappearSpeed;
        moveSpeed = Random.Range(minSpeed, minSpeed);
        objectManager = FindObjectOfType<ObjectManager>();
        ranRotateSpeed = Random.Range(1,5);
        ranRotateWay = new Vector3(Random.Range(0,2), Random.Range(0, 2), Random.Range(0, 2));
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * moveSpeed * (-1);

        if (disappearTime < Time.time && gameObject.tag == "star")
            StarPool.ReturnObject(gameObject);

        if (transform.position.z < objectManager.player.transform.position.z - 100 && gameObject.tag == "enemy")
            ObjectPool.ReturnObject(gameObject);

        if(gameObject.tag == "enemy")
        {
            gameObject.transform.Rotate(ranRotateWay * ranRotateSpeed);
        }
    }
}
