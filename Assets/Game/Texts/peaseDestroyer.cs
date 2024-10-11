using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peaseDestroyer : MonoBehaviour
{
    public float min = 0.6f , max = 6f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy ( gameObject,Random.Range ( min,max ) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
