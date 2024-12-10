using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam; // Corrected 'Camera' capitalization
    public float zoomSpeed; // Corrected 'zoomSpeed' capitalization
    public KeyCode zButton; // Corrected 'zButton' capitalization

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>(); // Corrected 'Camera' capitalization
    }

    void FixedUpdate()
    {
        if (Input.GetKey(zButton))
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, Time.deltaTime * zoomSpeed); // Corrected 'zoomSpeed' capitalization
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, Time.deltaTime * zoomSpeed); // Corrected 'zoomSpeed' capitalization
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
