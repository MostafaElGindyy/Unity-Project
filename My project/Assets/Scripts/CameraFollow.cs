using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;
    public float minX, maxX;
    public float minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, target.position, Time.deltaTime * cameraSpeed);
            float clampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float clampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }

    void Update()
    {
    }
}