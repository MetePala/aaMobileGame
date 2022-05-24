using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCircle : MonoBehaviour
{

  
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("arrow"))
        {
            col.collider.transform.SetParent(transform);
           

        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("arrow"))
        {
            GameManager._kalan--;
            if (GameManager._kalan == 0)
            {
                FindObjectOfType<GameManager>().LevelUp();
            }
        }
    }
}
