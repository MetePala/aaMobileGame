using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowCompanent : MonoBehaviour
{

    private void Awake()
    {
       
    }

    //private void OnCollisionStay2D(Collision2D col)
    //{
    //    if (col.gameObject.CompareTag("circle"))
    //    {
    //        transform.SetParent(col.collider.transform);
    //    }
       
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

}
