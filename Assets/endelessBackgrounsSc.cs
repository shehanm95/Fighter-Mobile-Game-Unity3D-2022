using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endelessBackgrounsSc: MonoBehaviour
    {

    BoxCollider2D mycollider;
    Rigidbody2D rb;
    public float scrollingSpeed;
    float   width;
    // Start is called before the first frame update
    void Start ( )
        {
        rb = GetComponent<Rigidbody2D> ( );
        mycollider = GetComponent<BoxCollider2D> ( );

        width = mycollider.size.x;
        mycollider.enabled = false;

        rb.velocity = new Vector2 ( scrollingSpeed,0 );
        }

    // Update is called once per frame
    void Update ( )
        {
        if (transform.position.x < -width)
            {
            Vector2 resetPosition = new Vector2 (width*2f, 0);
            transform.position = ( Vector2 )transform.position + resetPosition;
            }
        }
    }
