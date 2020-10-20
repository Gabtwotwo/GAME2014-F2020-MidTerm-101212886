//------------------------------------------
// Gabriel Villeneuve, 101212886
// EnemyController.cs
// Moves the enemies up and down
// Last Modified 2020-10-20
//------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //Changed the code to affect the enemies in a vertical manner. New bound values assigned, and changing code to affect them in the Y axis, not the X axis.

    //Vertical speed of our enemies
    public float verticalSpeed;

    //Boundary to check against if we need to switch their direction
    public float verticalBoundary;

    //Direction that they are going (Could technically be a bool since it only operates between 1 and -1, and bools are nice for two states only)
    public float direction;

    // Update is called once per frame
    void Update()
    {

        //Move the enemies
        _Move();

        //Verify if the enemies need to be turned around
        _CheckBounds();
    }

    private void _Move()
    {
        //Smoothly move the enemies up and down, thanks again deltatime for smooth movement
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check top boundary
        if (transform.position.y >= verticalBoundary)
        {
            //Change the direction the enemies move if they hit the top boundary
            direction = -1.0f;
        }

        // check bottom boundary
        if (transform.position.y <= -verticalBoundary)
        {
            //Same as the other check
            direction = 1.0f;
        }
    }
}
