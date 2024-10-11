using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playPanel : MonoBehaviour
{
    AudioClip bm1;
    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        bm1 = Resources.Load<AudioClip> ( "LostMusic" );
        au = GetComponent<AudioSource> ( );
        au.PlayOneShot ( bm1 );
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoLevels ()
        {
        StartCoroutine ( golvelsI ( ) );
        }

    public void ExitGame ( )
        {
        StartCoroutine ( ExitGameI ( ));
        }


    IEnumerator golvelsI ( )
        {
        au.Stop ( );
        yield return new WaitForSeconds ( 1.5f );
        SceneManager.LoadScene ( "levels" );
        }

    IEnumerator ExitGameI ( )
        {
        au.Stop ( );
        yield return new WaitForSeconds ( 1.5f );
        Application.Quit ( );
        }
    }
