using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _rotateSpeed;
    [SerializeField] GameObject _mainCircle;
    [SerializeField] Animator _buttonanim;
    [SerializeField] Animator _cameraAnim;
    static public int _level=1;
    static public int _kalan=4;
    [SerializeField] Text _kalanText;
    [SerializeField] Text _levelText;
    [SerializeField] GameObject _LevelUpCanvas;
    [SerializeField] Button _button;
    [SerializeField] GameObject _arrowSpawner;
    [SerializeField] GameObject _panel;
    bool levelup;
    bool sagadon;
    bool rotate=false;
    private void Awake()
    {
        Time.timeScale = 1;
        _kalan = PlayerPrefs.GetInt("kalan");
        _level = PlayerPrefs.GetInt("level");
        _rotateSpeed = PlayerPrefs.GetFloat("rotatespeed");
        _levelText.text = _level.ToString();
        _kalanText.text = _kalan.ToString();
        PlayerPrefs.SetInt("kalan", _kalan);
        //PlayerPrefs.SetInt("kalan", 4);
        //PlayerPrefs.SetInt("level", 1);
        //PlayerPrefs.SetFloat("rotatespeed", 50);
    }

    private void FixedUpdate()
    {
    
        if(rotate==false)
        {
            if (levelup == true)
            {
                //_rotateSpeed = 70;
                //if (!sagadon)
                //{
                //    _mainCircle.transform.Rotate(0f, 0f, (_rotateSpeed) * Time.deltaTime);
                //    StartCoroutine(Lvl2());
                //}

                //else
                //    _mainCircle.transform.Rotate(0f, 0f, -(_rotateSpeed) * Time.deltaTime);
            }
            else
            {
                    _mainCircle.transform.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
            }

        }
        else
        {
            _mainCircle.transform.Rotate(0f, 0f, 0);
        }
        



        _kalanText.text = _kalan.ToString();
    }
    IEnumerator Lvl2()
    {
        yield return new WaitForSeconds(3f);
        sagadon = true;
        yield return new WaitForSeconds(1.5f);
        sagadon = false;
    }


    public void GameOver()
    {
        Debug.Log("Game Over");
        StartCoroutine(Over());
    }
    IEnumerator Over()
    {
        rotate = true;
        _button.interactable = false;
        yield return new WaitForSeconds(0.01f);
        _buttonanim.SetTrigger("_gameover");
        _cameraAnim.Play("cameraanim");
        PlayerPrefs.SetInt("level", _level);
        PlayerPrefs.SetFloat("rotatespeed", _rotateSpeed);
        yield return new WaitForSeconds(1.1f);
        _panel.SetActive(true);

    }
    public void LevelUp()
    {
        _buttonanim.SetTrigger("_levelup");
        _LevelUpCanvas.SetActive(true);
        _button.interactable = false;
    }
    public void LevelUPClick()
    {
        _button.interactable = true;
        int childs = _mainCircle.transform.childCount;
        for (int i = childs-1; i >= 0; i--)
        {
            GameObject.Destroy(_mainCircle.transform.GetChild(i).gameObject);
        }


        _buttonanim.SetTrigger("_nextlevel");
        _kalan = PlayerPrefs.GetInt("kalan")+1;
        //if (_kalan >=11)
        //    levelup = true;
        PlayerPrefs.SetInt("kalan", _kalan);
        _LevelUpCanvas.SetActive(false);
        _level++;
        _levelText.text = _level.ToString();
        _rotateSpeed += 20;
        PlayerPrefs.SetFloat("rotatespeed", _rotateSpeed);
        PlayerPrefs.SetInt("level", _level);
    }
   
}
