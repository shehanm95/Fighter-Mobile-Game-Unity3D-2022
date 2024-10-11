using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zoom: MonoBehaviour
    {

    public Camera cam;
    public Slider zoomSlider;

    void Start ( )
        {
       
        
        }

    void Update ( )
        {

        cam.fieldOfView = zoomSlider.value;
        }
    }