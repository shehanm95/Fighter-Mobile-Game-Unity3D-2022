using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class makesummery : MonoBehaviour
{
    int activelevel;
    public Text StateText , helthText ,  ScoreText , enemiesKilledText , FinalSummeryText;
    float helthT , ScoreT, KildT , persentage , fullScore , helthp, scorep, killp;
    public float expectedFullScore, ScoreToFill , atificialKillrate , savedFullScore;
    public GameObject exitB , restartB , nextLevelB , rankImageI , Env , WinMusic , LostMusic;
    public GameObject[] stars;
    AudioSource au;
    AudioClip coinsound , h1s , coinCompleate , clickSound;
    int staractivationint , currentSceneIndex;
    public Image rankImageHolder;
    string RankNumberString , finalSummery;
    Sprite rankimage;

    
    // Start is called before the first frame update
    void Start()
    {
        Env.SetActive ( false );
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        activelevel = PlayerPrefs.GetInt ( "savedlevel",0 );
        au = GetComponent<AudioSource> ( );
        coinsound = Resources.Load<AudioClip> ( "coin" );
        clickSound = Resources.Load<AudioClip> ( "clickSound" );
        h1s = Resources.Load<AudioClip> ( "h1s" );
        coinCompleate = Resources.Load<AudioClip> ( "coincopleate" );
        activelevel = PlayerPrefs.GetInt ( "savedlevel",0 );
        int currlevel = SceneManager.GetActiveScene ( ).buildIndex;
        print ( "cur level : " + currlevel + "  || savedlevel : " + activelevel);
        gameManager.score =gameManager.playerHelth * 3;
        makeTheDefaltScoreAccordingtoPlayerDeadPlace ( );
        persentage = (gameManager.score / expectedFullScore) * 100;
        makeTtheStarActivationInt ( );
        print ( "star ac int" + staractivationint + "  || " +persentage);

        // making the ranks
        
        savedFullScore = PlayerPrefs.GetFloat ( "savedFullScore",0f );
        MakeRankNumberStringAccordingToFullScore ( );
        MakinAll3Pluses ( );
        au.Stop ( );

        }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DisplaySummery ( string SummeryState )
        {
        StartCoroutine ( MakkinSummery ( SummeryState ) );
        }

    IEnumerator MakkinSummery ( string SummeryState )
        {
        if (SummeryState == "win") {
            WinMusic.SetActive ( true );
            StateText.text = "m i s s i o n  s u c c e s s f u l"; }
        else {
            LostMusic.SetActive ( true );
            StateText.text = "y o u   D e f e a t e d"; }

        yield return new WaitForSeconds ( 0.5f );

        if (SummeryState == "win")
            {
            while (helthT < gameManager.playerHelth)
                {
                helthT += helthp;
                helthText.text = helthT.ToString ( "00" ) + " / 100";
                au.PlayOneShot ( coinsound );
                yield return new WaitForSeconds ( 0.09f );
                }
            }
        else
            {
            helthT = 100;
            helthText.color = new Color32 ( 255,0,82,255 );
            while (helthT > 0)
                {
                helthT -= 5f;
                helthText.text = helthT.ToString ( "00" ) + " / 100";
                au.PlayOneShot ( coinsound );
                yield return new WaitForSeconds ( 0.09f );
                }
            }
        yield return new WaitForSeconds ( 1f );

        while (ScoreT < gameManager.score)
            {
            ScoreT += scorep;
            ScoreText.text = ScoreT.ToString ( "00000" );
            au.PlayOneShot ( coinsound );
            yield return new WaitForSeconds ( 0.09f );
            }

        yield return new WaitForSeconds ( 1f );


        while (KildT < gameManager.killedEnemyRate)
            {
            KildT += killp;
            enemiesKilledText.text = KildT.ToString ( "0000" );
            au.PlayOneShot ( coinsound );
            yield return new WaitForSeconds ( 0.09f );
            }
        

        yield return new WaitForSeconds ( 1.8f );
        if (SummeryState == "win")
            {
            rankImageI.SetActive ( true );
            au.PlayOneShot ( coinCompleate );
            yield return new WaitForSeconds ( 1f );
            }
            //star activations===============

        for (int i = 0 ; i < staractivationint ; i++)
            {
            yield return new WaitForSeconds ( 0.4f );
            stars [ i ].SetActive ( true );
            au.PlayOneShot ( h1s );
            }

        // DisplayFinal Summery;
        yield return new WaitForSeconds ( 0.5f );
        FinalSummeryText.text = finalSummery;

        yield return new WaitForSeconds (1f );

        if (SummeryState == "win") {
            nextLevelB.SetActive ( true );
            yield return new WaitForSeconds ( 3f );
            exitB.SetActive ( true );
            restartB.SetActive ( true );
            }
         else { 
            restartB.SetActive ( true );
            yield return new WaitForSeconds ( 3f );
            exitB.SetActive ( true );
            }
        }



    public void GoToNextLevel ( )
        {
        StartCoroutine ( GoToNextLevelI ( ) );
        }

    void makeTheDefaltScoreAccordingtoPlayerDeadPlace ( )
        {

        float fulllength  = GameObject.Find ( "winObject" ).transform.position.x;
        float playerPosition = GameObject.Find ( "player" ).transform.position.x;
        ScoreToFill =(playerPosition / fulllength) * ScoreToFill;
        print ( $" killing score and , score to fill : { gameManager.score } || {ScoreToFill} " );
        gameManager.score = gameManager.score + ScoreToFill;

        atificialKillrate = (playerPosition / fulllength) * atificialKillrate;
        gameManager.killedEnemyRate = gameManager.killedEnemyRate + atificialKillrate;
        }

    void MakinAll3Pluses ( )
        {
        if (gameManager.playerHelth > 80)
            {
            helthp = 2f;
            }
        else if (gameManager.playerHelth > 50)
            {
            helthp = 1.5f;
            }
        else if (gameManager.playerHelth > 20)
            {
            helthp = 1f;
            }
        else if (gameManager.playerHelth > 0)
            {
            helthp = 0.5f;
            }


        if (gameManager.score > 100)
            {
            scorep = 0.02f * gameManager.score;
            }
        else if (gameManager.score > 50)
            {
            scorep = 2f;
            }

        else if (gameManager.score > 0)
            {
            scorep = 1f;
            }



        if (gameManager.killedEnemyRate > 100)
            {
            killp = 0.18f * gameManager.killedEnemyRate;
            }
        else if (gameManager.killedEnemyRate > 50)
            {
            killp = 1.2f;
            }
        else if (gameManager.killedEnemyRate > 0)
            {
            killp = 1f;
            }

        print ( $" helth score and kill plusses : { helthp} || { scorep} || { killp} || score {gameManager.score}" );
        }
    void makeTtheStarActivationInt ( )
        {
        if (persentage > 75)
            {
            staractivationint = 3;
            finalSummery = "E X E LE N T";
            FinalSummeryText.color = new Color32 ( 0,255,20,255 );
            return;
            }
        else if (persentage > 40)
            {
            staractivationint = 2;
            finalSummery = "N O R M A L   S K I LL";
            FinalSummeryText.color = new Color32 ( 0,15,255,255 );
            return;
            }
        else if (persentage > 10)
            {
            staractivationint = 1;
            finalSummery = "P O O R   S K I LL";
            FinalSummeryText.color = new Color32 (255,0,82,255 );  
            return;
            }
        else
            {
            finalSummery = "V E R Y   B A D   S K I LL";
            FinalSummeryText.color = new Color32 ( 255,0,82,255 );
            return;
            }
        }

   

    void MakeRankNumberStringAccordingToFullScore ( )
        {
        if (activelevel <= currentSceneIndex)
            {
            fullScore = gameManager.score + savedFullScore;
            }

        else
            {
            fullScore = savedFullScore;

            }

       settingString ( );

        rankimage = Resources.Load<Sprite> ( $"Ranks/rank{RankNumberString}" );
        rankImageHolder.GetComponent<Image> ( ).sprite = rankimage;


        }

    void settingString ( )
        {
        if (fullScore > 580)
            {
            RankNumberString = "2";
            return;
            }
        else if (fullScore > 0)
            {
            RankNumberString = "1";
            return;
            }
        }

    IEnumerator GoToNextLevelI ( )
        {
        au.PlayOneShot ( clickSound );
        WinMusic.SetActive ( false );
        LostMusic.SetActive ( false );
        yield return new WaitForSeconds ( 1.5f);
        print ( activelevel );
        if (activelevel <= currentSceneIndex)
            {
            PlayerPrefs.SetInt ( "savedlevel",currentSceneIndex);
            print ( "deviaed by 1" );
            PlayerPrefs.SetFloat ( "savedFullScore",fullScore );
            SceneManager.LoadScene ( "levels" );
            }

        else
            {
            SceneManager.LoadScene ( "levels" );
            print ( "deviaed by 2" );
            }
        }

    public void restart ( )
        {
        StartCoroutine ( restartI ( ) );
        }
    public void exitgame ( )
        {
        au.PlayOneShot ( clickSound );
        StartCoroutine ( exitgameI ( ) );
        }

    IEnumerator restartI ( )
        {
        au.PlayOneShot ( clickSound );
        WinMusic.SetActive ( false );
        LostMusic.SetActive ( false );
        yield return new WaitForSeconds ( 1.5f );
        SceneManager.LoadScene ( SceneManager.GetActiveScene ( ).buildIndex );
        Time.timeScale = 1;
        }

    IEnumerator exitgameI ( )
        {
       
        WinMusic.SetActive ( false );
        LostMusic.SetActive ( false );
        yield return new WaitForSeconds ( 1.5f );
        SceneManager.LoadScene ( "levels" );
        Time.timeScale = 1;
        }

    }
