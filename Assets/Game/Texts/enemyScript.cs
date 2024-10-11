using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    float far ,  yfar, absFar;
    public bool nearing, onceAttack;
    private bool attack = false;
    public float enemySpeed ,enemySpeedWhnAttack, attackDistance , nearingDistance , enemyPain = 4000;
    bool die = false;
    float move = -1 ;
    public GameObject[] actions;
    public GameObject attackSprite , run , idle ,dieSprite , stand;
    AudioSource au;
    AudioClip h1s;

    int gotAttackShotCount = 4;
    // Start is called before the first frame update

    void Start ( )
        {
        au = GetComponent<AudioSource> ( );
        rb = GetComponent<Rigidbody2D> ( );
        player = GameObject.Find ( "player" );
       
        }



    // Update is called once per frame
    void Update ( )
        {
        if (!die)
            {
            far = transform.position.x - player.transform.position.x;
            yfar = transform.position.y - player.transform.position.y;

           
              //  print ( yfar );
                if (far > 0)
                    {

                    transform.localRotation = Quaternion.Euler ( 0,180,0 );
                    }
                else
                    {

                    transform.localRotation = Quaternion.Euler ( 0,0,0 );
                    }
                if (far < 0)
                    {
                    move = 1;
                    }
                else
                    {
                    move = -1;
                    }
                absFar = Mathf.Abs ( far );

                if (player.GetComponent<playerControls> ( ).attackedEnemyCount > 1 && !attack)
                    {
                    nearing = false;
                    idle.SetActive ( true );
                    run.SetActive ( false );
                    }

                else if (absFar < attackDistance)
                    {
                    nearing = false;
                    attack = true;


                    }
                else if (absFar < nearingDistance && !die && absFar > attackDistance)
                    {
                    nearing = true;
                    attack = false;
                    }
                else if (absFar > nearingDistance)
                    {
                    idle.SetActive ( true );
                    attackSprite.SetActive ( false );
                    }

                if (attack && yfar > 0)
                    {
                    onceAttack = true;
                    idle.SetActive ( false );
                    run.SetActive ( false );
                    }
                if (nearing)
                    {
                    idle.SetActive ( false );
                    attackSprite.SetActive ( false );
                    }
               
            }
        }

    private void FixedUpdate ( )
        {
        if (nearing && !die)
            {
            run.SetActive ( true );
            rb.velocity = new Vector2 ( move * enemySpeed * Time.deltaTime,rb.velocity.y );
            }
        
        if (die)
            {
            //rb.velocity = new Vector2 ( -move * enemySpeed  / 5, - enemySpeed / 5 );
            dieSprite.SetActive ( true );
            run.SetActive ( false );
            GetComponent<BoxCollider2D> ( ).enabled = false;
            GetComponent<CircleCollider2D> ( ).enabled = false;
            GetComponent<CapsuleCollider2D> ( ).enabled = false;
            }
        if (attack && !die)
            {
            attackSprite.SetActive ( true );
            run.SetActive ( false );
            }

        if(onceAttack && absFar > attackDistance)
            {
            attack = false;
            nearing = true;
            player.GetComponent<playerControls> ( ).attackedEnemyCount = 0;
            }
        }

    
    private void OnTriggerEnter2D ( Collider2D collision )
        {
        
                {
                if (collision.gameObject.tag == "h1" || collision.gameObject.tag == "h2s" || collision.gameObject.tag == "k1s" || collision.gameObject.tag == "k2s" || collision.gameObject.tag == "jk2s" || collision.gameObject.tag == "jk1s" || collision.gameObject.tag == "jh2s" || collision.gameObject.tag == "jh1s" || collision.gameObject.tag == "uh1s" || collision.gameObject.tag == "uk2s" || collision.gameObject.tag == "uk1s")
                    {
                    diefunc ( );
                    }
                if (collision.gameObject.tag == "extra")
                    {
                    extradiefunc ( );
                    }

                if (collision.gameObject.tag == "gotAttackShot")
                    {
                    gotAttackShotCount--;
                    //rb.velocity = new Vector2 ( move * enemySpeed * Time.deltaTime,rb.velocity.y );
                    if (gotAttackShotCount < 1)
                        {
                        player.GetComponent<playerControls> ( ).attackedEnemyCount--;
                        gameManager.killedEnemyRate++;
                        diefunc ( );
                        }
                    //print ( "hit" );
                    }
                }
            

        }

    private void stateFalser ( )
        {
        foreach (GameObject action in actions)
            {
            action.SetActive ( false );
            }
        }

    void diefunc ( )
        {
        playHShotSoundFunc ( );
        gameManager.killedEnemyRate += 1;
        gameManager.score += 10;
        print ( gameManager.score );
        if ( move == -1)
            {
                 rb.AddForce ( Vector2.right * enemyPain );
            }
        else
            {
            rb.AddForce ( Vector2.right * -enemyPain );
            }
        rb.AddForce ( Vector2.up * enemyPain );
        die = true;
        attackSprite.SetActive ( false );
        dieSprite.SetActive ( true );
        Destroy ( gameObject,3f );
        idle.SetActive ( false );
        // print ( "hit" );
        player.GetComponent<playerControls> ( ).attackedEnemyCount = 0;
        }
    void extradiefunc ( )
        {
        playHShotSoundFunc ( );
        if (move == -1)
            {
            rb.AddForce ( Vector2.right * 400 );
            }
        else
            {
            rb.AddForce ( Vector2.right * -400 );
            }
        rb.AddForce ( Vector2.up * 20 );
        die = true;
        attackSprite.SetActive ( false );
        dieSprite.SetActive ( true );
        idle.SetActive ( false );
       // stand.SetActive ( false );
        Destroy ( gameObject,3f );
        // print ( "hit" );
        player.GetComponent<playerControls> ( ).attackedEnemyCount = 0;
        }


    void playHShotSoundFunc ( )
        { do
             {
              gameManager.numA = Random.Range ( 1,7 );
              }while (gameManager.numA == gameManager.numB);
              string num = gameManager.numA.ToString();
              gameManager.numB = gameManager.numA;
              h1s = Resources.Load<AudioClip> ( $"h{num}s" );
              au.PlayOneShot ( h1s );
            }
    }
