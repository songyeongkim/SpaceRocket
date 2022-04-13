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

    void LateUpdate()
    {
        transform.position = searchPlayer.transform.position + cameraPos;
    }
}
