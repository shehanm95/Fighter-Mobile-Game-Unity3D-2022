using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.Linq;

public class playerControls : MonoBehaviour 
{
    Vector2 finalPosition;
    AudioClip  h1s , h2s, hj1s , hj2s , hu1s , hu2s, k1s , k2s , kj1s , kj2s, ku1s, ku2s ,jumpS, js ,  uMoves ,  shocks , dies , avoids , wins , gotAttacks , gotAttackShots , helthpickupsound;
    AudioSource au;
    public float speed , gotAttackSpeed , USpeed;
    Rigidbody2D rb;
    bool waitTimeFinished = true , inALastState = false;
    public GameObject idle , h1 , h2, hj1 , hj2 , hu1 , hu2, k1 , k2 , kj1 , kj2, ku1, ku2 , j , uIdle , uMove , move, shock , die , avoid , win , gotAttack , gotAttackShot , battryCharge;
    personalinput personalInput;
   

    bool under , up , gotattack , updateactivator;
    public GameObject[] actions;
    bool run , onGotAttackShot , died =  false;
    public int attackedEnemyCount;
    float move1;
    string[] enemys;

    [Header("=====  U I Objects  =====")]
    public GameObject progressPanel;
    public GameObject  GamePanel ;
    public Image HelthFill;
    public Slider playerHelthslider;
    public Text playerHelthText;

    [Header ( "===== Audio Objects  =====" )]
    public GameObject backgroundMusic;
    public GameObject winmusic , looseMusic;

    

    // Start is called before the first frame update
    void Start()
    {
        
        makeUSpeed ( );
        h1s = Resources.Load<AudioClip> ( "h1s" );
        helthpickupsound = Resources.Load<AudioClip> ( "helthPickupSound" );
        jumpS = Resources.Load<AudioClip> ( "jumpSound" );
        au = GetComponent<AudioSource> ( ); 
        rb = GetComponent<Rigidbody2D> ( );
        idle.SetActive ( true );
        gameManager.win = false;
        personalInput = FindObjectOfType<personalinput> ( ).gameObject.GetComponent<personalinput>();
        

        
     }

    private void Jump_performed ( UnityEngine.InputSystem.InputAction.CallbackContext obj )
        {
        jump ( );
        print ( obj );
        }

    // Update is called once per frame
    void Update()
    { }

    private void FixedUpdate ( )
        {
        if (!died)
            {
            if (attackedEnemyCount == 0 && gotattack)
                {
                gotattack = false;
                stateFalser ( );
                if (move1 != 0 && !up)
                    {
                    UMoveOrMove ( );
                    }
                else
                    {

                    // idle.SetActive ( true );
                    }
                }

            if (Application.platform == RuntimePlatform.Android)
                {
                move1 = personalInput.movementVector.x;
                }
            else
                {
                move1 = Input.GetAxisRaw ( "Horizontal" );
                //move1 = CrossPlatformInputManager.GetAxis ( "Horizontal" );
                }
            if (move1 == 1)

                {
                transform.localRotation = Quaternion.Euler ( 0,0,0 );

                }
            if (move1 == -1)
                {
                transform.localRotation = Quaternion.Euler ( 0,180,0 );

                }


            if (gotattack)
                {

                gotAttack.SetActive ( true );
                rb.velocity = new Vector2 ( move1 * gotAttackSpeed * Time.deltaTime,rb.velocity.y );
                }
            else
                {
                if (up)
                    { rb.velocity = new Vector2 ( move1 * speed * 2 * Time.deltaTime,rb.velocity.y ); }
                else if (under)
                    {
                    rb.velocity = new Vector2 ( move1 * USpeed * Time.deltaTime,rb.velocity.y );
                    }
                else
                    { rb.velocity = new Vector2 ( move1 * speed * Time.deltaTime,rb.velocity.y ); }

                if (move1 == 0 && run && !up)
                    {
                    run = false;
                    stateFalser ( );
                    IdleOrSitIdle ( );
                    }
                else if (move1 != 0 && !run && !up)
                    {
                    run = true;
                    stateFalser ( );
                    UMoveOrMove ( );

                    }
                }

            if (!up && !updateactivator)
                {
                updateactivator = true;
                if (move1 == 0)
                    {
                    run = false;
                    stateFalser ( );
                    IdleOrSitIdle ( );
                    }
                else if (move1 != 0)
                    {
                    run = true;
                    stateFalser ( );

                    UMoveOrMove ( );
                    }
                }
            }

        else
            {
            //dead animation play
            stateFalser ( );
            transform.position = new Vector2(finalPosition.x , transform.position.y);
            die.SetActive ( true );
            }


        }



    // fixed end=======================================
    IEnumerator JumpF ()
        {
        if (waitTimeFinished && !up && !gotattack)
            {
            stateFalser ( );
            addforceToJump ( );
            j.SetActive ( true );
            waitTimeFinished = false;
            up = true;
            updateactivator = false;
            yield return new WaitForSeconds ( 1f );
            if (move1 != 0)
                {
                idle.SetActive ( false );
              //  move.SetActive ( true );
                }
            else
                {
               //  idle.SetActive ( true );
                }
            waitTimeFinished = true;
            j.SetActive ( false );
            up = false;
            }
        }
    public void jump ( )
        {
        if (under)
            {under = false;
             GetComponent<CapsuleCollider2D> ( ).enabled = true;
                GetComponent<BoxCollider2D> ( ).enabled = true;
             //   GetComponent<PolygonCollider2D> ( ).enabled = false;
                IdleOrSitIdle ( );
            }
        else
            {StartCoroutine ( "JumpF");
            au.PlayOneShot ( jumpS );
            }
        }
    void addforceToJump ( )
        {
        if (!up)
            {
            rb.AddForce ( Vector2.up * 400);
            }
        }

    public void underF ( )
        {
        under = true;
        move.SetActive ( false );
        IdleOrSitIdle ( );
        GetComponent<CapsuleCollider2D> ( ).enabled = false;
        GetComponent<BoxCollider2D> ( ).enabled = false;
        GetComponent<PolygonCollider2D> ( ).enabled = true;
        }


    public void h1f ( )
        {
        if (gotattack)
            {
            gotattackShotFunction ( );
            }
        else if (up)
            {
            StartCoroutine ( shot ( 2f,hj1 ) );
            }
        else if (under)
            {
            StartCoroutine ( shot ( 1f,hu1 ) );
            }
        else { StartCoroutine ( shot ( 0.4f,h1 ) );
            
            }
        
        }

    
    public void h2f ( )
        {
        if (gotattack)
            {
            gotattackShotFunction ( );
            }
        else if (up)
            {
            StartCoroutine ( shot ( 2f,hj2 ) );
            rb.AddForce ( Vector2.right * 200 );
            }
        else if (under)
            {
            StartCoroutine ( shot ( 0.4f,hu2 ) );
            }
        else { StartCoroutine ( shot ( 0.4f,h2 ) );
            
            }
        }

    public void k1f ( )
        {
        if (gotattack)
            {
            gotattackShotFunction ( );
            }
            else if (up)
            {
            StartCoroutine ( shot ( 0.4f,kj1 ) );
            }
        else if (under)
            {
            StartCoroutine ( shot ( 0.4f,ku1 ) );
            }
        else { StartCoroutine ( shot ( 0.4f,k1 ) ); 
            }
        }

      public void k2f ( )
        {
        if (gotattack)
            {
            gotattackShotFunction ( );
            }
            else if (up)
            {
            StartCoroutine ( shot ( 0.4f,kj2) );
            }
        else if (under)
            {
            StartCoroutine ( shot ( 0.4f,ku2 ) );
            }
        else { StartCoroutine ( shot ( 0.9f,k2 ) ); 
            }
        }


    IEnumerator shot ( float waitTime , GameObject shot)
        {
        if(waitTimeFinished || up)
            {
            if (up)
                {
                StopCoroutine ( "jumpF" );
                }
            waitTimeFinished = false;
            idle.SetActive ( false );
            j.SetActive ( false );
            move.SetActive ( false );
            uMove.SetActive ( false );
            uIdle.SetActive ( false );
            shot.SetActive ( true );
            yield return new WaitForSeconds ( waitTime );
            stateFalser ( );
            IdleOrSitIdle ( );
            waitTimeFinished = true;
            if (move1 != 0 && !up)
                {
                idleFalser ( );
                // yield return new WaitForSeconds ( waitTime );
                UMoveOrMove ( );
                }
            }
        }



    IEnumerator GotAttackshotFunction ( float waitTime,GameObject shot )
        {
        if (waitTimeFinished)
            {
            onGotAttackShot = true;
            waitTimeFinished = false;
            gotAttack.SetActive ( false );
            shot.SetActive ( true );
            yield return new WaitForSeconds ( waitTime );
            stateFalser ( );
           // gotAttack.SetActive ( true );
            waitTimeFinished = true;

            if(gotattack == false)
                {
                stateFalser ( );
                if (run)
                    {
                    UMoveOrMove ( );
                    }
                else
                    {

                    IdleOrSitIdle ( );
                    }
                }
        
            }
        }

    private void stateFalser ( )
        {
        foreach (GameObject action in actions)
            {
            action.SetActive ( false );
            }
        if (gotattack)
            {
           // gotAttack.SetActive ( true );
            }
        }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if(collision.gameObject.tag == "enemyAttack")
            {
            attackedEnemyCount++;
            stateFalser ( );
           // gotAttack.SetActive ( true );
           if(gameManager.playerHelth > 5)
                {gameManager.playerHelth -= 5;}
           else
                {gameManager.playerHelth -= 5;
                    GamePanel.SetActive ( false );
                    if (!died)
                        {
                        died = true;
                        StartCoroutine ( activatesummerypanel ( "dead",3f) );
                        }
                  //  GetComponent<playerControls> ( ).enabled = false;
                }

            playerHelthslider.value = gameManager.playerHelth;
            playerHelthText.text = gameManager.playerHelth.ToString ( "00" ) + "%";
            changeTheColorAccordingToHelth ( );
            }

        if (collision.gameObject.tag == "jumpobj" || collision.gameObject.tag == "crrepwaight")
            {
            if (gameManager.playerHelth > 5)
                { gameManager.playerHelth -= 5; }
            else
                {
                gameManager.playerHelth -= 5;
                dieF ( );
                GamePanel.SetActive ( false );
                if (!died)
                    {
                    died = true;
                    finalPosition = transform.position;
                    StartCoroutine ( activatesummerypanel ("dead"));}
                }
            playerHelthslider.value = gameManager.playerHelth;
            playerHelthText.text = gameManager.playerHelth.ToString ( "00" ) + "%";
            changeTheColorAccordingToHelth ( );
            }

        if (collision.gameObject.tag == "helthbottle")
            {
            StartCoroutine( BaterryChargeF ( ) );
            Destroy ( collision.gameObject );
            au.PlayOneShot ( helthpickupsound,0.69f );
            if ( gameManager.playerHelth + 30 < 100)
                { gameManager.playerHelth += 30; }
            else
                {
                gameManager.playerHelth = 100;
                }
            playerHelthslider.value = gameManager.playerHelth;
            playerHelthText.text = gameManager.playerHelth.ToString ( "00" ) + "%";
            changeTheColorAccordingToHelth ( );
            }

        if (collision.gameObject.tag == "activatesummery")
            {
            inALastState = true;
            GamePanel.SetActive ( false );
            stateFalser ( );
            win.SetActive ( true );
            StartCoroutine ( activatesummerypanel ("win" ) );
            }

        if (gameManager.playerHelth < 0) { gameManager.playerHelth = 0;
            playerHelthText.text = gameManager.playerHelth.ToString ( "00" ) + "%";
            }
        }

    private void OnTriggerStay2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "enemyAttack")
            {
            move1 = 0;
            if (attackedEnemyCount == 0)
                {
                attackedEnemyCount = 1;
                }
                gotattack = true;
            if (!onGotAttackShot)
                {
                gotAttack.SetActive ( true );
                gotAttackShot.SetActive ( false );
                }
            else
                {
                gotAttack.SetActive ( false );
                gotAttackShot.SetActive ( true );
                }
            idleFalser ( );
            }
        
        }
    
    void gotattackShotFunction ( )
        {
        if (attackedEnemyCount == 0 )
            {
            onGotAttackShot = true;
            gotattack = false;
            stateFalser ( );
            
        }
        else
            {
            StartCoroutine ( GotAttackshotFunction ( 0.1f,gotAttackShot ) ); // got attack make shock
            if (gotattack == true)
                {
                gotattack = false;
                idleFalser ( );
                }
            }
        }

    void UMoveOrMove ( )
        {
        if (!under)
            {
            move.SetActive ( true );
            uMove.SetActive ( false );
            }
        else if (under)
            {
            uMove.SetActive ( true );
            move.SetActive ( false );
            }
        }

    void IdleOrSitIdle ( )
        {
        if (!inALastState)
            {
            if (under)
                {
                uIdle.SetActive ( true );
                idle.SetActive ( false );
                }
            else
                {
                uIdle.SetActive ( false );
                idle.SetActive ( true );
                }
            }
        }

    void idleFalser ( )
        {
        uIdle.SetActive ( false );
        idle.SetActive ( false );
        }


    IEnumerator activatesummerypanel (string state , float time = 5f )
        {
        backgroundMusic.SetActive ( false );
        if(state == "win")
            {
            winmusic.SetActive ( true );
            }
        else
            {
            looseMusic.SetActive ( true );
            }
        yield return new WaitForSeconds (time );
        print ( "summery lated" );
        progressPanel.SetActive ( true );
        GameObject.Find ( "progresspanel" ).GetComponent<makesummery> ( ).DisplaySummery (state);
        }
   
    public void changeTheColorAccordingToHelth ( ) {
        if (gameManager.playerHelth < 30)
            {
            HelthFill.color = new Color32 ( 255,11,11,255 );
            playerHelthText.color = new Color32 ( 255,11,11,255 );
            }
        else
            {
            HelthFill.color = new Color32 ( 11,255,34,255 );
            playerHelthText.color = new Color32 ( 11,255,34,255 );
            }
        }

    void dieF ( )
        {
        inALastState = true;
        stateFalser ( );
        die.SetActive ( true );
        }

    IEnumerator BaterryChargeF ( )
        {
        battryCharge.SetActive ( true );
        yield return new WaitForSeconds ( 4f );
        battryCharge.SetActive ( false );
        }

    public void makeUSpeed ( )
        {
        speed = gameManager.playerSpeed;
        USpeed = speed / 80f * 37f;
        }
}
