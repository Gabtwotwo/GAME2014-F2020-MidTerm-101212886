//------------------------------------------
// Gabriel Villeneuve, 101212886
// BackgroundController.cs
// Allows for seamless background scrolling
// Last Modified 2020-10-20
//------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    //Changed the bounds to horizontal, code simply changed to affect the X axis as opposed to the Y axis.

    //Horizontal speed of the backgrounds
    public float horizontalSpeed;

    //Boundary at which the backgrounds reset themselves
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {

        //Move the backgrounds
        _Move();

        //Verify that the backgrounds are in the proper boundary
        _CheckBounds();

 
    }

    private void _Reset()
    {

        //Set the position of the background back to the front of the screen on reset
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }

    private void _Move()
    {

        //Slowly and smoothly (thanks, DeltaTime) scrolls the background from the right to the left
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

}
