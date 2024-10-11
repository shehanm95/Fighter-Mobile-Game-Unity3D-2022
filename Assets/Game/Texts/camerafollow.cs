using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow: MonoBehaviour
    {
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    public Vector3 offset2;
    Vector3 targetPos;
    // Use this for initialization
    void Start ( )
        {
        targetPos = transform.position;
        offset2.x = -offset.x + 2;
        offset2.y = offset.y;
        offset2.z = offset.z;
        }

    // Update is called once per frame
    void FixedUpdate ( )
        {
        print ( "camera : " + target.transform.localEulerAngles.x );

        if (target)
            {
            if (target.transform.localEulerAngles.y < 10)
                {
                Vector3 posNoZ = transform.position;
                posNoZ.z = target.transform.position.z;

                Vector3 targetDirection = (target.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude * 70f;

                targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

                transform.position = Vector3.Lerp ( transform.position,targetPos + offset,0.25f );
                }
            else
                {
                Vector3 posNoZ = transform.position;
                posNoZ.z = target.transform.position.z;

                Vector3 targetDirection = (target.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude * 70f;

                targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

                transform.position = Vector3.Lerp ( transform.position,targetPos + offset2,0.25f );
                }

            }
        }
    }

