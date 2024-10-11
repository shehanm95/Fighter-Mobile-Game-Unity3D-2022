using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clamper : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find ( "player" ).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < ( gameObject.transform.position.y + 3 ) && player.position.y > (gameObject.transform.position.y - 3))
            {
            if (player.position.x < (gameObject.transform.position.x + 3) && player.position.x > (gameObject.transform.position.x - 3))
                {
                GetComponent<BoxCollider2D> ( ).enabled = true;
                }
            }
    }
}
