using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.IncreaseScore();
            Destroy(gameObject);
        }
        else if (collision.tag == "Boundary")
        {
            GameManager.instance.DecreaseLife();
            Destroy(gameObject);
        }
    }
}
