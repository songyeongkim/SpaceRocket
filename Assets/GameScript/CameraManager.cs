using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject searchPlayer;
    Vector3 cameraPos;

    private void Start()
    {
        cameraPos = transform.position - searchPlayer.transform.position;
    }

    void Update()
    {
        // if(transform.position != searchPlayer.transform.position + cameraPos)
        //transform.position = Vector3.Lerp(transform.position, searchPlayer.transform.position + cameraPos, 500f * Time.deltaTime);
        transform.position = searchPlayer.transform.position + cameraPos;
    }
}
