using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyActivator : MonoBehaviour
{
    public GameObject stand , enemy
        ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if ( collision.gameObject.tag == "land")
            {
            enemy.SetActive ( true );
            stand.SetActive ( false );
            }

        }
    }

