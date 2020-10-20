//--------------------------------------------------
// Gabriel Villeneuve, 101212886
// BulletController.cs
// Moves the bullets that have been fired at random
// Last Modified 2020-10-20
//--------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{

    //More detailed variables on what the bullets do. Same application for other .cs scripts so far.
    public float verticalSpeed;
    public float verticalBoundary;
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        //Find our bullet manager in the scene
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(verticalSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.x > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        //This would let us know what the bullet hit
        //Debug.Log(other.gameObject.name);

        //Bring the bullet back into the bullet manager pool, if it hits anything.
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {

        //Doesn't do much right now
        return damage;
    }
}
