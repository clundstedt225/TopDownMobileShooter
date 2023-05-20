using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script rotates and aims the weapon transform

public class PlayerAimWeapon : MonoBehaviour
{

    [SerializeField] private Transform aimTransform;

    // Update is called once per frame
    void Update()
    {
        //Get first touch and convert from pixel coords to world space
        Touch touch = Input.GetTouch(0);
        Vector3 fPos = Camera.main.ScreenToWorldPoint(touch.position);
        fPos.z = 0f;

        //Get the player to finger direction
        Vector3 aimDir = (fPos - transform.position).normalized;

        //Get angle in radians, then convert to degrees by multiplying
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

        //Apply rotation
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
