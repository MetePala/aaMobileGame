using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    [SerializeField] GameObject _arrow;
    float _currentTime;
    [SerializeField]bool aktimMi;
    private void Awake()
    {
    }
    public void ArrowThrow()
    {
       if(aktimMi==true)
        {
            Instantiate(_arrow, transform.position, transform.rotation, transform);
            _currentTime = 0;
        }
        
    }
    private void FixedUpdate()
    {
        _currentTime += Time.deltaTime;
        if( _currentTime>=0.06f)
        {
            aktimMi = true;
        }
        else
        {
            aktimMi = false;
        }
    }
}
