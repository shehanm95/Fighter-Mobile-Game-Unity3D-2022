using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class plyerControl : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    string currentState;
    bool waitTimeFinished = true;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D> ( );
        anim = player.GetComponent<Animator> ( );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate ( )
        {
        if (waitTimeFinished)
            {
            float move = CrossPlatformInputManager.GetAxis("Horizontal");
            rb.velocity = new Vector2 ( move * speed * Time.deltaTime,rb.velocity.y );
            if(move == 0)
                {
                playAnim ( "idle" );
                }
            }
        }


    public void k1 ( )
        {
        waitTimeFinished = false;
        playAnim ( "k1" );
        StartCoroutine ( waitAttacktime ( 0.4f ) );
        Vector3 newpos = transform.position;
        newpos.x = transform.position.x + 6;
        transform.position = Vector3.MoveTowards ( transform.position,newpos, 0.6f );
        }

    public void hand1 ( )
        {
        waitTimeFinished = false;
        playAnim ( "h1" );
        StartCoroutine ( waitAttacktime ( 0.4f ) );
        Vector3 newpos = transform.position;
        newpos.x = transform.position.x + 6;
        transform.position = Vector3.MoveTowards ( transform.position,newpos,0.6f );
        }

    public void playAnim (string newState )
        {
        if (newState == currentState) return;

        anim.Play ( newState );

        currentState = newState;
        }



    IEnumerator waitAttacktime ( float waitTime )
        {
        yield return new WaitForSeconds ( waitTime );
        waitTimeFinished = true;
        }

    }
