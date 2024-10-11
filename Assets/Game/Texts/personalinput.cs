using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personalinput : MonoBehaviour
{
    public Vector2 movementVector;
    PlayerInputActions playeractions;
    playerControls player;
    private void Awake ( )
        {
        playeractions = new PlayerInputActions();
        playeractions.Player.Enable ( );
        playeractions.Player.jump.performed += Jump_performed;
        playeractions.Player.creep.performed += Creep_performed;
        player = FindObjectOfType<playerControls> ( );

        }

    private void Creep_performed ( UnityEngine.InputSystem.InputAction.CallbackContext obj ) => player.underF ( );
    private void Jump_performed ( UnityEngine.InputSystem.InputAction.CallbackContext obj )=>player.jump ( );
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = playeractions.Player.Movements.ReadValue<Vector2> ( );
        
    }
}
