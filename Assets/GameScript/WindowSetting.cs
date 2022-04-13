using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSetting : MonoBehaviour
{
    public int setWidth;
    public int setHeight;

    void Start()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        setWidth = 1920;
        setHeight = 1080;

        Screen.SetResolution(setWidth, setHeight, false);
    }
}
