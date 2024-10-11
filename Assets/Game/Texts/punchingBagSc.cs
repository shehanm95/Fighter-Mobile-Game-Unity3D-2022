using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchingBagSc : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject[] ticks;
    bool h1 , h2 , k1 , k2;
    public GameObject chainFirst , fullbag , good;
    AudioClip punchingBagSound;
    AudioSource au;
    // Start is called before the first frame update
    void Start ( )
        {
        rb = GetComponent<Rigidbody2D> ( );
        punchingBagSound = Resources.Load<AudioClip>("PunchingBag");
        au = GetComponent<AudioSource> ( );

        }

    // Update is called once per frame
    void Update ( )
        {
        }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "jh1s")
            {
        
            rb.AddForce ( Vector2.right * 200 );
            ticks [ 0 ].SetActive ( true );
            au.PlayOneShot ( punchingBagSound );
            h1 = true;
            endfunction ( );
            }
        if (collision.gameObject.tag == "jh2s")
            {
            rb.AddForce ( Vector2.right * 200 );
            ticks [ 1 ].SetActive ( true );
            au.PlayOneShot ( punchingBagSound );
            h2 = true;
            endfunction ( );
            }

        if (collision.gameObject.tag == "jk2s")
            {
            rb.AddForce ( Vector2.right * 200 );
            au.PlayOneShot ( punchingBagSound );
            ticks [ 2 ].SetActive ( true );
            k1 = true;
            endfunction ( );
            }
        if (collision.gameObject.tag == "jk1s")
            {
            rb.AddForce ( Vector2.right * 200 );
            au.PlayOneShot ( punchingBagSound );
            ticks [ 3 ].SetActive ( true );
            k2 = true;
            endfunction ( );
            }

        }

   

    void endfunction ( )
        {
        if (h1 && h2 && k1 && k2)
            {
            GetComponent<CapsuleCollider2D> ( ).enabled = false;
            chainFirst.SetActive ( false );
            rb.AddForce ( Vector2.right * 70 );
            rb.AddForce ( Vector2.up * 200 );
            transform.Rotate ( 0f,0f,-50f );
            Destroy ( fullbag,2.5f );
            good.SetActive ( true );

            }
        }

    }

