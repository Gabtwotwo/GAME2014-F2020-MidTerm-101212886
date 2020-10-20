//------------------------------------------
// Gabriel Villeneuve, 101212886
// BulletType.cs
// Simple, global enum for bullet types
// Last Modified 2020-10-20
//------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BulletType
{

    //Just an enum for the different types of bullets that randomly shoot, convenient for wherever we need it
    REGULAR,
    FAT,
    PULSING,
    RANDOM
}
