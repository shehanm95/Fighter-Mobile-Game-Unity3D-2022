using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicopter : MonoBehaviour
{
    public Transform HelicopterDoorTr , Player;
    GameObject HelicopterEnemy;
    float playerposition;
    bool move = false , dropping  = true;
    Vector2 newHeliCopPosition;
    int positionNum;
    // Start is called before the first frame update
    void Start()
    {
        HelicopterEnemy = Resources.Load<GameObject> ( "enemy2" );
        StartCoroutine ( droping ( ) );
        StartCoroutine ( heliproceed ( ) );
    }

    // Update is called once per frame
    void Update ( )
        {

        }

    private void FixedUpdate ( )
        {
        if (move)
            {
            if (positionNum == 1)
                {
                newHeliCopPosition = new Vector2 ( Player.transform.position.x + 12,transform.position.y );
                transform.position = Vector2.Lerp ( transform.position,newHeliCopPosition,Time.deltaTime * 0.5f );
                transform.localRotation = Quaternion.Euler ( 0,180,0 );
                }
            if (positionNum == 2)
                {
                newHeliCopPosition = new Vector2 ( Player.transform.position.x -12,Player.transform.position.y + 7);
                transform.position = Vector2.Lerp ( transform.position,newHeliCopPosition,Time.deltaTime * 0.5f );
                transform.localRotation = Quaternion.Euler ( 0,0,0 );
                }
            if (positionNum == 3)
                {
                newHeliCopPosition = new Vector2 ( Player.transform.position.x + 12,Player.transform.position.y + 6);
                transform.position = Vector2.Lerp ( transform.position,newHeliCopPosition,Time.deltaTime * 0.5f );
                transform.localRotation = Quaternion.Euler ( 0,180,0 );
                }
            if (positionNum == 4)
                {
                newHeliCopPosition = new Vector2 ( Player.transform.position.x -30,Player.transform.position.y + 7 );
                transform.position = Vector2.Lerp ( transform.position,newHeliCopPosition,Time.deltaTime * 0.5f );
                transform.localRotation = Quaternion.Euler ( 0,0,0 );
                }
            }
        }

    void DropEnemy ( )
        {
        Instantiate ( HelicopterEnemy,HelicopterDoorTr.position,Quaternion.identity );
        }

    IEnumerator droping ( )
        {
        if (dropping)
            {
            yield return new WaitForSeconds ( 2f );
            move = false;
            DropEnemy ( );
            yield return new WaitForSeconds ( 0.3f );
            move = true;
            StartCoroutine ( droping ( ) );
            }
        }

    IEnumerator heliproceed ( )
        {
        yield return new WaitForSeconds ( 1f );
        positionNum = 1;
        yield return new WaitForSeconds ( 6f );
        positionNum = 2;
        yield return new WaitForSeconds ( 6f );
        positionNum = 3;
        yield return new WaitForSeconds ( 6f );
        positionNum = 1;
        yield return new WaitForSeconds ( 6f );
        positionNum = 2;
        yield return new WaitForSeconds ( 6f );
        positionNum = 3;
        yield return new WaitForSeconds ( 6f );
        dropping = false;
        positionNum = 4;
        Destroy ( gameObject,6f );
        }


}
