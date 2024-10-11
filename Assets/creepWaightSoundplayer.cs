using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creepWaightSoundplayer : MonoBehaviour
{
    AudioClip creepwaightSound;
    AudioSource u;
    // Start is called before the first frame update
    void Start()
    {
        u = GetComponent<AudioSource> ( );
        creepwaightSound = Resources.Load<AudioClip> ( "chainWaightSound" );

        }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D ( Collision2D collision )
        {
        u.PlayOneShot ( creepwaightSound );
        }
    }
