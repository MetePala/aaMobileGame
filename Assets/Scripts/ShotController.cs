using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    [SerializeField] GameObject _arrow;
    private void Awake()
    {
    }
    public void ArrowThrow()
    {
        Instantiate(_arrow, transform.position, transform.rotation, transform);
    }
}
