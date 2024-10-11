using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEnemyActivator : MonoBehaviour
{
    GameObject player;
    public GameObject MyChild;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find ( "player" );
    }

    // Update is called once per frame
    void Update()
    {
       if(player != null)
            {
            if(player.transform.position.x > transform.position.x){
                MyChild.SetActive ( true );
                }
            } 
    }
}
