using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static float playerHelth = 100;
    public static float killedEnemyRate , score , playerSpeed;
    public static bool win = false , loose = false;
    public static int  numA , numB;
    // Start is called before the first frame update
    void Start()
    {
       // playerHelth = 20;
        killedEnemyRate = 0;
        score = 0;
        print ( "score reseted" );
        playerSpeed = PlayerPrefs.GetFloat ( "playerSpeed",100f );
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void pauseGame ( )
        {
        Time.timeScale = 0;
        }
    }
