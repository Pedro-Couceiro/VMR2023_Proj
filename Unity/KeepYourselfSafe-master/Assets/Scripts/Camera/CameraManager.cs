using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance => _instance;
    
    
    public float horizontalResolution = 1920;
    public float verticalResolution = 1080;

    private void Awake()
    {
        if (_instance == null) { _instance = this; }
        else { Destroy(gameObject); }
    }

    public float GetHorizontalRes()
    {
        return horizontalResolution;
    }

    public float GetVerticalRes()
    {
        return verticalResolution;
    }
    
    private void OnGUI()
    {
        float currentAspectRatio = (float)Screen.width / (float)Screen.height; 
        Camera.main.orthographicSize = horizontalResolution / currentAspectRatio / 200f;
    }
}
