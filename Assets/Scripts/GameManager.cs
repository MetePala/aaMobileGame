using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _rotateSpeed;
    [SerializeField] GameObject _mainCircle;
    [SerializeField] Animator _buttonanim;
    static public int _level=1;
    static public int _kalan=4;
    [SerializeField] Text _kalanText;
    [SerializeField] Text _levelText;
    [SerializeField] GameObject _LevelUpCanvas;
    [SerializeField] Button _button;
    private void Awake()
    {
        _kalanText.text = _kalan.ToString();
        PlayerPrefs.SetInt("kalan", _kalan);
    }

    private void FixedUpdate()
    {
        _mainCircle.transform.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
        _kalanText.text = _kalan.ToString();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        StartCoroutine(Over());
    }
    IEnumerator Over()
    {
        _buttonanim.SetTrigger("_gameover");
        yield return new WaitForSeconds(0.02f);
        Time.timeScale = 0;
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
        PlayerPrefs.SetInt("kalan", _kalan);
        _LevelUpCanvas.SetActive(false);
        _level++;
        _levelText.text = _level.ToString();
        _rotateSpeed += 20;
    }
   
}
