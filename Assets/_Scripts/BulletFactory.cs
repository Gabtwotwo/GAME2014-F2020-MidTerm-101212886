//------------------------------------------------------------
// Gabriel Villeneuve, 101212886
// BulletFactory.cs
// Where the bullet that is fired is decided, and instantiated
// Last Modified 2020-10-20
//------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{

    //The three types of bullets, which are connected to prefabs once they're made.
    [Header("Bullet Types")]
    public GameObject regularBullet;
    public GameObject fatBullet;
    public GameObject pulsingBullet;



    public GameObject createBullet(BulletType type = BulletType.RANDOM)
    {

        //Make a random bullet, then bring it through the switch case
        if (type == BulletType.RANDOM)
        {
            var randomBullet = Random.Range(0, 3);
            type = (BulletType) randomBullet;
        }

        GameObject tempBullet = null;

        //Check what kind of bullet RANDOM made, instantiate it, and give it the proper damage.
        switch (type)
        {
            case BulletType.REGULAR:
                tempBullet = Instantiate(regularBullet);
                tempBullet.GetComponent<BulletController>().damage = 10;
                break;
            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                tempBullet.GetComponent<BulletController>().damage = 20;
                break;
            case BulletType.PULSING:
                tempBullet = Instantiate(pulsingBullet);
                tempBullet.GetComponent<BulletController>().damage = 30;
                break;
        }

        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);

        //Send back the bullet to be fired.
        return tempBullet;
    }
}
