using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All gun/raycast weapon scripts inherit from this

public abstract class Gun : MonoBehaviour
{
    protected Transform barrelPos;

    public virtual void Shoot(Touch touch)
    {
        Debug.Log("bang...");
    }
}
