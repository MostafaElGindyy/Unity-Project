using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Capitalized Transform
    public float cameraSpeed; // Corrected float
    public float minX, maxX; // Changed variable order for clarity
    public float minY, maxY; // Changed variable order for clarity

    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate() // Corrected method name
    {
        if (target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, target.position, Time.deltaTime * cameraSpeed); // Corrected Lerp method parameters
            float clampX = Mathf.Clamp(newCamPosition.x, minX, maxX); // Corrected method and variable names
            float clampY = Mathf.Clamp(newCamPosition.y, minY, maxY); // Corrected method and variable names
            transform.position = new Vector3(clampX, clampY, -10f); // Changed variable names for clarity
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}