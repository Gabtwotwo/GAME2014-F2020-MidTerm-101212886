//------------------------------------------------------------
// Gabriel Villeneuve, 101212886
// BulletManager.cs
// The pool of 50 bullets, and the center where all bullets go
// Last Modified 2020-10-20
//------------------------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{

    //Utilize the bullet factory to get what bullets needs to be fired
    public BulletFactory bulletFactory;

    //Max amount of bullets that can exist in-world at all times
    public int MaxBullets;

    //Queue of bullets, randomized and always of size 50
    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update
    void Start()
    {

        //Make a pool. Wee!
        _BuildBulletPool();
    }

    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();


        //Fill the pool with some bullets, randomized thanks to bulletFactory. Make whatever the max is.
        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }


    //This is for the player controller to get the bullet it can fire.
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;

        //Had to add a rotation to the bullets, thought it would be better to do in code instead of in the prefab.
        newBullet.transform.rotation = Quaternion.Euler(0, 0, -90);
        return newBullet;
    }


    //Basically the amount of bullets we have left
    public bool HasBullets()
    {
        return m_bulletPool.Count > 0;
    }


    //Place the bullet at the back of the queue, and de-activate it. Thanks for the trip!
    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
