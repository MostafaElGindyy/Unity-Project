using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    public float zoomSpeed;
    public KeyCode zButton; 
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(zButton))
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, Time.deltaTime * zoomSpeed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, Time.deltaTime * zoomSpeed);
        }
    }

    void Update()
    {
        
    }
}