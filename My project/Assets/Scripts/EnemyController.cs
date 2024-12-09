using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] // Fixed attribute syntax
    public bool isFacingright = false;
    public float maxSpeed = 2;
    public int damage = 6; // Fixed spacing and syntax

    public void flip()
    {
        isFacingright = !isFacingright;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Fixed syntax and type name
    }

    void OnTriggerEnter2D(Collider2D other) // Fixed method and type names
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<playerstate>().takedamage(damage); // Assumes playerstate is defined elsewhere
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
