using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayerSpeed : MonoBehaviour
{
    public Slider playerSpeedSlider;
    float newPlayerSpeed;
    public Text NewHelthValueText;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeedSlider.value = gameManager.playerSpeed;
        newPlayerSpeed = playerSpeedSlider.value;
        NewHelthValueText.text = newPlayerSpeed.ToString ( "0" );
        }

    // Update is called once per frame
    void Update()
    {

        gettingValue ( );
    }

    void gettingValue ( )
        {
        newPlayerSpeed = playerSpeedSlider.value;
        NewHelthValueText.text = newPlayerSpeed.ToString ( "0" );
        }

    public void svaingValues ( )
        {
        PlayerPrefs.SetFloat ( "playerSpeed",newPlayerSpeed );
        gameManager.playerSpeed = newPlayerSpeed;
        GameObject.Find ( "player" ).GetComponent<playerControls> ( ).makeUSpeed ( );
        }



}
