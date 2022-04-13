using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraRotateSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(1,1,0) * cameraRotateSpeed);
    }
}
