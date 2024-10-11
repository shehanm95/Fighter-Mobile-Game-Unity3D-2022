using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarrowcontrolss : MonoBehaviour
{
    public GameObject normal, shoted , Base , good;
    Rigidbody2D rb;
    bool h1 , h2 , k1, k2;
    public GameObject[] ticks;
    AudioClip scarrowSound;
    AudioSource u;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ( );
        u = GetComponent<AudioSource> ( );
        scarrowSound = Resources.Load<AudioClip> ( "scarrowSound" );
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
       
        if (collision.gameObject.tag == "h1")
            {
            u.PlayOneShot ( scarrowSound );
            StartCoroutine ( "shot" );
                ticks [ 0 ].SetActive ( true );
                h1 = true;
                 endfunction ( );


            }
        if (collision.gameObject.tag == "h2s")
            {
            u.PlayOneShot ( scarrowSound );
            StartCoroutine ( "shot" );
                ticks [ 1].SetActive ( true );
            h2 = true;
            endfunction ( );
            }

        if (collision.gameObject.tag == "k2s")
            {
            u.PlayOneShot ( scarrowSound );
            StartCoroutine ( "shot" );
                ticks [ 2 ].SetActive ( true );
            k1 = true;
            endfunction ( );
            }
        if (collision.gameObject.tag == "k1s")
            {
            u.PlayOneShot ( scarrowSound );
            ticks [ 3 ].SetActive ( true );
            StartCoroutine ( "shot" );
            k2 = true;
            endfunction ( );
            }

        }

    IEnumerator shot ( )
        {
        normal.SetActive ( false );
        shoted.SetActive ( true );
        yield return new WaitForSeconds ( 0.5f );
        normal.SetActive (true );
        shoted.SetActive (false);
        }

    void endfunction ( )
        {
        if (h1 && h2 && k1 && k2)
            {
            GetComponent<BoxCollider2D> ( ).enabled = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine ( "shot" );
            Base.SetActive ( false );
            rb.AddForce ( Vector2.right * 70 );
            rb.AddForce ( Vector2.up * 200 );
            transform.Rotate ( 0f,0f,-50f );
            Destroy ( gameObject,4f );
            good.SetActive ( true );
            }
        }




  }
