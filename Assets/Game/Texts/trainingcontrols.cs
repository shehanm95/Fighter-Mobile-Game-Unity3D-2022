using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trainingcontrols : MonoBehaviour {

    public Text consoletext;
    bool texted = false , HandActivated;
    public float waitTime = 2f;
    public Color green, red;
    int num1 , num2 = 7 ;
    Slider zoomSlider;

    [Header ("BUTTON OBJECTS")]

    public GameObject[] controllButtons;
    public GameObject[] ShotButtons;
    public GameObject ZoomGuideHand;
    

    [ Header ("BUTTON IMAGES")]
    public Image[] controllButtonImages;
    public GameObject[] ShotButtonImages;
    bool doingBlinking;
    private bool zooming = false;

    // Start is called before the first frame update
    void Start()
    {
        zoomSlider = GameObject.Find ( "CameraZoom" ).GetComponent<Slider>();
      
        

        }

    // Update is called once per frame
    void Update()
    {
       print ( gameObject.transform.position.x );
        if (!texted) { 
            if (gameObject.transform.position.x > -5 && gameObject.transform.position.x < 8)
                {
                SetSlider ( 41 );
                consoletext.text = "W e l c o m e  t  o   t h e   f i g h t e r   t r a i n i n g   s c h o o l . . . . . \ng o   a h e a d. . . . ,";
                int[] b ={ 2} ;
                buttonBlinker ( b);
                }
            else if (gameObject.transform.position.x >9 && gameObject.transform.position.x < 10)
                 {
               
                consoletext.text = "y o u   h a v e   t o   d o   t h e   t r a i n i n g   f i r s t ,   \ng o   f r o n t . . . .";
                handactivatorF ( );
                 }

            else if ( gameObject.transform.position.x > 11 && gameObject.transform.position.x < 20)
                {
               
                consoletext.text = "p r e s s   u p   a r r o w   k e y   t  o   j u m p  . . . . . ";
                int[] b ={ 0,2} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 21 && gameObject.transform.position.x < 29)
                {
              //  StartCoroutine ( SetSlider ( 55f ) );
                consoletext.text = "g o o d . . . . . . . . . !";
                int[] b ={ 0,2} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 31 && gameObject.transform.position.x < 34)
                {
              
                consoletext.text = "n o w   y o u   p a s s e d   t h e   j u m p   t e s t . . . .";
                }

            else if ( gameObject.transform.position.x > 35 && gameObject.transform.position.x < 45)
                {
              
                consoletext.text = "p r e s s   d o w n   a r r o w   k e y   t  o    c r e e p  . . . . . ";
                int[] b ={ 3,2} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 47 && gameObject.transform.position.x < 49.5f)
                {
                consoletext.text = "p r e s s   u p   a r r o w k e y   t o   a v o i d\nt o    j u m p   o b j e c t . . . . . .";
                int[] b ={ 0,2} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 49.5f && gameObject.transform.position.x < 51)
                {
                consoletext.text = "g o o d . . . . . . . . . !";
                }
            else if ( gameObject.transform.position.x > 51 && gameObject.transform.position.x < 57)
                {
                consoletext.text = "c r e e p   a g a i n . . . .";
                int[] b ={ 3,2} ;
                buttonBlinker ( b );    
                }
            else if ( gameObject.transform.position.x > 58 && gameObject.transform.position.x < 61)
                {
                consoletext.text = "p r e s s   u p   a r r o w k e y   t o   a v o i d\nt o    j u m p   o b j e c t . . . . . .";
                int[] b ={ 0,2} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 63 && gameObject.transform.position.x < 67)
                {
                consoletext.text = "g o o d . . . . . . . . . !";
                int[] b ={ 0} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 67 && gameObject.transform.position.x < 69)
                {
                consoletext.text = "g e t   t h e   m e d i c i n e   b o t t l e \nt o   i n c r a s e   y o u r  h  e l t h . . . . . .";
                int[] b ={ 2} ;
                buttonBlinker ( b , 1f );
                }
            else if ( gameObject.transform.position.x > 73 && gameObject.transform.position.x < 76)
                {
                consoletext.text = "r e a d y   t o   t r a i n g   b a s i c   s h o t s   w i t h   \nt h e   s h o t   b u t t o n s . . . . . . . . . !";
                 SetSlider ( 42f ) ;
                int[] b ={ 4,5,6,7} ;
                buttonBlinker ( b , 0.1f );
                }
            else if ( gameObject.transform.position.x > 77 && gameObject.transform.position.x < 84)
                {
                consoletext.text = "s e e   t h e   i n s t r u c t i o n   b o a r d   a n d   p r e s s   t h e   k e y s   a c c o r d i n g   t o   t h a t . . . . . . . . . !";
                int[] b ={ 2,4,5,6,7} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 86 && gameObject.transform.position.x < 90)
                {
                consoletext.text = "g o o d . . . . . . . . . !";
                }
            else if ( gameObject.transform.position.x > 91 && gameObject.transform.position.x < 98)
                {
                consoletext.text = "r e a d y   t o   t r a i n g   f l i n g   s h o t s   w i t h   \nt h e   s h o t   b u t t o n s . . . . . . . . . !";

                }
            else if ( gameObject.transform.position.x > 98 && gameObject.transform.position.x < 104)
                {
                consoletext.text = "s e e   t h e   i n s t r u c t i o n   b o a r d   a n d   p r e s s   t h e   k e y s   a c c o r d i n g   t o   t h a t . . . . . . . . . !";
               do
                    {
                    num1 = Random.Range ( 4,8 );
                    } while (num1 == num2);
                
                int[] b ={ 0, 2,num1} ;
                num2 = num1;
                buttonBlinker ( b );
                }
            else if (gameObject.transform.position.x > 104 && gameObject.transform.position.x < 106)
                {
                consoletext.text = "s e e   t h e   i n s t r u c t i o n   b o a r d   a n d   p r e s s   t h e   k e y s   a c c o r d i n g   t o   t h a t . . . . . . . . . !";
                do
                    {
                    num1 = Random.Range ( 4,8 );
                    } while (num1 == num2);

                int[] b ={ 0,num1} ;
                num2 = num1;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 108 && gameObject.transform.position.x < 113)
                {
                SetSlider ( 60 );
                consoletext.text = "g o o d . . . . . . . . . !";
                handactivatorF ( );
               
                }
            else if ( gameObject.transform.position.x > 116 && gameObject.transform.position.x < 125)
                {
                consoletext.text = "s e e   t h e   i n s t r u c t i o n   b o a r d   a n d   p r e s s   t h e   k e y s   a c c o r d i n g   t o   t h a t . . . . . . . . . !";
                }
            else if ( gameObject.transform.position.x > 128 && gameObject.transform.position.x < 132)
                {
                consoletext.text = "D O   T H E   S H O T S   A C C O R D I N G   T O   T H E   P O T   A N D   B R E A K E   T H E M . . . . ";
                int[] b ={ 3,2,5} ;
                buttonBlinker ( b );
                }
            else if (gameObject.transform.position.x > 136 && gameObject.transform.position.x < 137.7f)
                {
                consoletext.text = "D O   T H E   S H O T S   A C C O R D I N G   T O   T H E   P O T   A N D   B R E A K E   T H E M . . . . ";
                int[] b ={ 3,2,6} ;
                buttonBlinker ( b );
                }
            else if (gameObject.transform.position.x > 139 && gameObject.transform.position.x < 143)
                {
                consoletext.text = "D O   T H E   S H O T S   A C C O R D I N G   T O   T H E   P O T   A N D   B R E A K E   T H E M . . . . ";
                int[] b ={ 3,2,7} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 149 && gameObject.transform.position.x < 152)
                {
                SetSlider ( 60f ) ;
                consoletext.text = "J U M P   A N D   G O   T O   M I D D L E   O F   T H E  H 1   P O T S .   .  .  . \n B U T   A V O I D   T H E   O B S T I C A L   ! ! ! ";
                int[] b ={ 0,2,3} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 154 && gameObject.transform.position.x < 156)
                {
                SetSlider ( 49f );
                consoletext.text = "B R E A K E   T H E   P O T   BY U S I N G  H 1   S H O T S  .   .  .  . ";
                int[] b ={ 3, 4} ;
                buttonBlinker ( b );
                }
            else if ( gameObject.transform.position.x > 157 && gameObject.transform.position.x < 160)
                {
                consoletext.text = "n o w   y o u   p a s s e d   A L L   t h e   t e s t  S, \ni n   t h e   t r a i n i n g   s c h o o l s . .  .  .   .  .  . ";
                int [] b ={ 0, 2} ;
                buttonBlinker ( b , 1f);
                }
            else if (gameObject.transform.position.x > 160 && gameObject.transform.position.x < 170)
                {
                SetSlider ( 65 );
                consoletext.text = "congratulations . . . .\nn o w   y o u   c a n   m o v e   t o   t h e   m i s s i o n s  .  .  .  .   .  .  . ";
                }

            }


        }
    private void OnTriggerStay2D ( Collider2D collision )
        {
        if (collision.gameObject.tag == "crrepwaight")
            {
            StopCoroutine ( "dotext" );
            StartCoroutine (dotext( "p l e a s e . . ,   p r e s s   d o w n   a r r o w   k e y   t o  g p   d o w n . . . ."));
            }
        if (collision.gameObject.tag == "jumpobj")
            {
            StopCoroutine ( "dotext" );
            StartCoroutine ( dotext ( "p l e a s e . . ,  p r e s s   u p   a r r o w   k e y   a n d  m o v e   l e f t  \n  t o   g o   f r o n t . . . . " ) );
            }

        }


    IEnumerator dotext ( string warning)
        {
        texted = true;
        consoletext.color = Color.red;
        consoletext.text = warning;
        yield return new WaitForSeconds ( waitTime );
        consoletext.text = "p l e a s e  b e   c a r e f u l . . . . !";
        yield return new WaitForSeconds ( 1f );
        consoletext.text = "";
       consoletext.color =Color.green;
        texted = false;
        }

    void handactivatorF ( )
        {
        if (!HandActivated)
            {
            StartCoroutine ( HandActivator () );
            }
        }
    IEnumerator HandActivator ( )
        {
        HandActivated = true;
        ZoomGuideHand.SetActive ( true );
        yield return new WaitForSeconds ( 4f);
        ZoomGuideHand.SetActive ( false );
        yield return new WaitForSeconds ( 20f );
        HandActivated = false;
        }


    void IncraseColorsInContrallButtons ( )
        {
        foreach (Image contrallButtonImage in controllButtonImages)
            {
            contrallButtonImage.GetComponent<Image> ( ).color = new Color32 ( 0,0,0 ,255 );
            }

        }

    public void buttonBlinker ( int[] ButtonNums ,float time = 0.4f )
        {
        if (!doingBlinking)
            {
            StartCoroutine ( buttonBlinkerI ( ButtonNums , time ) );
            }
        }

    IEnumerator buttonBlinkerI (int[] ButtonNums ,float time = 0.4f )
        {
        doingBlinking = true;
        foreach (int ButtonNum in ButtonNums)
            {
             yield return new WaitForSeconds ( time );
            controllButtonImages [ ButtonNum ].GetComponent<Image> ( ).color = new Color32 ( 255,255,255,230 );
            }
        yield return new WaitForSeconds ( 0.9f );
        foreach (int ButtonNum in ButtonNums)
            {
            controllButtonImages [ ButtonNum ].GetComponent<Image> ( ).color = new Color32 ( 255,255,255,45 );
            }
        doingBlinking = false;
        }


    void SetSlider ( float valueToSet )
        {
        if (!zooming && zoomSlider.value != valueToSet)
            {
             zooming = true;
            if (zoomSlider.value < valueToSet)
                {
                StartCoroutine ( uperrvaliving ( valueToSet ) );
                return;
                }
            else if (zoomSlider.value > valueToSet)
                {
                StartCoroutine ( undervaliving ( valueToSet ) );
                return;
                }
            }
       
        }

    IEnumerator uperrvaliving ( float valueToSet )
        {
        while (zoomSlider.value < valueToSet)
            {
            yield return new WaitForSeconds ( 0.1f );
            zoomSlider.value += 0.5f;
            }
        yield return new WaitForSeconds ( 5f );
        zooming = false;
        }
    IEnumerator undervaliving ( float valueToSet )
        {
        while (zoomSlider.value > valueToSet)
            {
            yield return new WaitForSeconds ( 0.1f );
            zoomSlider.value -= 0.5f;
            }
        yield return new WaitForSeconds ( 5f );
        zooming = false;
        }



    }
