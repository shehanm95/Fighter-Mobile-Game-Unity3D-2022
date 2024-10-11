using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelButtonActiver : MonoBehaviour {

    int activelevel;
    public Button[] buttons;
    public GameObject WinPanelMusic;

    void Start () {
        activelevel = PlayerPrefs.GetInt ("savedlevel" , 0);
       // activelevel = 2;

        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < (activelevel + 1); i++) {
            buttons[i].interactable = true;
            buttons[i].transform.GetChild ( 2 ).gameObject.SetActive ( false );
        }

    }

    // Update is called once per frame
    void Update () {

    }

    public void buttonFunction ( )
        {
        StartCoroutine ( buttonFunctionI ( ) );
        }

    public void GoToPlay ( )
        {
        StartCoroutine ( goToPlayI ( ) );
        }
    IEnumerator goToPlayI ( )
        {
        WinPanelMusic.SetActive ( false );
        yield return new WaitForSeconds ( 1.5f );
        SceneManager.LoadScene ( "play" );
        }

    IEnumerator buttonFunctionI ( )
        {
        WinPanelMusic.SetActive ( false );
        yield return new WaitForSeconds ( 1.5f );
        string name =  EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene ( name );
        }
    }