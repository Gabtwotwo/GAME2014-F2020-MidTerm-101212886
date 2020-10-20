using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        //CheckForChange();
 
    }

    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }

    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }


    void CheckForChange()
    {
        //This code always returned unknown so I abandoned it
            switch (Input.deviceOrientation)
            {
                case DeviceOrientation.Unknown:
                    //code
                    Debug.Log("Unknown");
                    break;
                case DeviceOrientation.Portrait:
                    //code
                    Debug.Log("Portrait");
                    break;
                case DeviceOrientation.LandscapeLeft:
                    //code
                    Debug.Log("Landscape Left");
                    break;
                case DeviceOrientation.LandscapeRight:
                    //code
                    Debug.Log("Landscape Right");
                    break;


            }
    }
}
