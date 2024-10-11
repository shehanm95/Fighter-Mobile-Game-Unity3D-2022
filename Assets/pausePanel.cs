using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausePanel : MonoBehaviour
{
    public GameObject pausePanelO, gamePanel, Env;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart ( )
        {
        StartCoroutine ( restartI ( ) );
        }
    public void exitgame ( )
        {
        StartCoroutine ( exitgameI ( ) );
        }

    IEnumerator restartI ( )
        {

        yield return new WaitForSecondsRealtime ( 1.1f );
        Time.timeScale = 1;
        SceneManager.LoadScene ( SceneManager.GetActiveScene ( ).buildIndex );
        }

    IEnumerator exitgameI ( )
        {

        yield return new WaitForSecondsRealtime ( 1.1f );
        Time.timeScale = 1;
        SceneManager.LoadScene ( "levels" );
        }

    public void resumeGame ( )
        {
        StartCoroutine ( resumeGameI ( ) );

        }

    IEnumerator resumeGameI ( )
        {
        yield return new WaitForSecondsRealtime ( 1.1f );
        Time.timeScale = 1;
        gamePanel.SetActive ( true );
        Env.SetActive ( true );
        pausePanelO.SetActive ( false );
        }
    }

