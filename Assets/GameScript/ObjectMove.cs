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
        //Debug.Log("start 오프젝트 풀링 시 어떻게 실행될까?");
        //오브젝트 풀링 시 start는 처음 생성되었을 때만 실행되는 것이 확인된다.
    }

    private void OnEnable()
    {
        //Debug.Log("onEnable 오프젝트 풀링 시 어떻게 실행될까?");
        //오브젝트 풀링 시 enable 될 때 마다 실행되는 것이 확인된다.
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
