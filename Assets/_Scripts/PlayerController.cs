//------------------------------------------
// Gabriel Villeneuve, 101212886
// PlayerController.cs
// Takes care of everything player related
// Last Modified 2020-10-20
//------------------------------------------



using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Allows access to our bullet manager
    public BulletManager bulletManager;


    //Both boundary checks. We honestly only need one since we only move in one dimension, but I didn't want to risk breaking anything by removing the horizontal boundary somehow
    [Header("Boundary Check")]
    public float verticalBoundary;
    public float horizontalBoundary;


    //Speed related variables. We technically try and lerp our position between our current vertical speed and max speed, but that doesn't work and it's not really required. Neat, though
    [Header("Player Speed")]
    public float verticalSpeed;
    public float maxSpeed;

    //Not sure what this does
    public float verticalTValue;


    //Amount of bullets shot in a timeframe. The lower the delay, the more bullets are fired. Since a max of 50 bullets can exist at a time, upping this value to break the game won't work.
    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables

     //Collision on our player. Since the enemies don't shoot at us, this only serves to move the player via touch input.
    private Rigidbody2D m_rigidBody;

    //A vector 3 of the last place our player has touched the screen
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {

        //Just init, basically
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Same as the background and enemy updates, but we fire a constant stream of bullets. It's detailed better in BulletManager, though.
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing. Only fire every 60 frames, basically
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        //Set our initial direction to 0 so we don't move
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support (Not super required)
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        //If the last place you touched isn't the same as your current position, smoothly make your way there
        if (m_touchesEnded.y != 0.0f)
        {
           transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * verticalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {

        //Since the device orientation is always unknown, I have to stop checking against DeviceOrientation or I get no checkBounds
        //if (Input.deviceOrientation == DeviceOrientation.Portrait)
        //{
        //    Debug.Log("Device Orientation Portrait");
        //    // check right bounds
        //    if (transform.position.x >= verticalBoundary)
        //    {
        //        transform.position = new Vector3(verticalBoundary, transform.position.y, 0.0f);
        //    }

        //    // check left bounds
        //    if (transform.position.x <= -verticalBoundary)
        //    {
        //        transform.position = new Vector3(-verticalBoundary, transform.position.y, 0.0f);
        //    }
        //}
        //else if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        //{

        // check up bounds
        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }

        // check downwards bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x,-verticalBoundary, 0.0f);
        }
    }
}
