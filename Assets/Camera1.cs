using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{

    public float worldWidth;
    public float worldHeight;
    Camera mainCamera;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        worldHeight = 35.0f * Camera.main.transform.localScale.y * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        worldWidth = 60.0f * Camera.main.transform.localScale.y * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        Debug.Log("Wielkoœæ pola gry: " + worldWidth + " x " + worldHeight);
    
    
    }
}
