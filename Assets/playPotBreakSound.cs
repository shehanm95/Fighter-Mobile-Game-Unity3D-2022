using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playPotBreakSound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip potbreakeSound;
    AudioSource u;
    void Start()
    {
        u = GetComponent<AudioSource> ( );
        potbreakeSound = Resources.Load<AudioClip> ( "potbreake" );
      

        }

    // Update is called once per frame
    void Update ( )
        {



        }
    public void PotBreakSoundPlay ( )
        {
        u.PlayOneShot ( potbreakeSound );
        }
}
