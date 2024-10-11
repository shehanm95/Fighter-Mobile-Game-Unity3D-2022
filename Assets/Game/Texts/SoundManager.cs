using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip  h1s , h2s, hj1s , hj2s , hu1s , hu2s, k1s , k2s , kj1s , kj2s, ku1s, ku2s , js ,  uMoves ,  shocks , dies , avoids , wins , gotAttacks , gotAttackShots ;
    public static AudioSource au;
    public static AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = Resources.Load<AudioClip> ( "h1s" );
        au = GetComponent<AudioSource> ( );
        
    }

    // Update is called once per frame
    void Update()
    {
        }

    public static void playSound ()
        {
        sound = Resources.Load<AudioClip> ( "h1s" );
        au.PlayOneShot ( sound );
        }


}
