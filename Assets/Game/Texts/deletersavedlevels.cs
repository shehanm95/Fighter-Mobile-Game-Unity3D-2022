using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletersavedlevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll ( );
        print ( "==== SAVED LEVELS ARE DELETED ====" );
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
