using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpeed : MonoBehaviour
{
   [SerializeField] Rigidbody2D _rgb;
    bool a=false;
    private void Start()
    {
        _rgb  = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       if(!a)
        _rgb.AddForce(transform.up * 600);
       else
        {
            Destroy(GetComponent<Rigidbody2D>());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("circle"))
        {
            a = true;
        }
        if (collision.gameObject.CompareTag("arrow"))
        {
            a = true;
            FindObjectOfType<GameManager>().GameOver();
        }
    }

}
