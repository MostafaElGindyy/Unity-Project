using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
<<<<<<< Updated upstream
    private void OnTriggerEnter(Collider other)
=======
    private SpriteRenderer sr;
    public Sprite explodedBlock;

    void Start()
>>>>>>> Stashed changes
    {
        if (other.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            Destroy(gameObject);
            gameObject.SetActive(false); // Makes the platform disappear
        }
=======
            if (other.gameObject.tag == "Player" && other.GetContact(0).point.y < transform.position.y)
            {
                sr.sprite = explodedBlock;
                Object.Destroy(gameObject, .2f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
>>>>>>> Stashed changes
    }
}