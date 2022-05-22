using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpeed : MonoBehaviour
{
   [SerializeField] Rigidbody2D _rgb;
    private void Start()
    {
        _rgb  = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rgb.AddForce(transform.up * 100);

    }
}
