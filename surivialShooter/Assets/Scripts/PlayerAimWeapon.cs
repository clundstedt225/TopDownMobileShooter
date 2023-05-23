using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//This script rotates and aims the weapon transform

public class PlayerAimWeapon : MonoBehaviour
{

    [SerializeField] private Transform aimTransform;

    // Update is called once per frame
    void Update()
    {
        //Should we handle aiming logic
        if (Input.touchCount > 0) { 
            //Update weapon aim
            HandleAiming();
        }
    }

    void HandleAiming()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 fPos = Camera.main.ScreenToWorldPoint(touch.position);
        fPos.z = 0f;

        //2d raycast (UI may be different???)
        Vector2 touchPosWorld2D = new Vector2(fPos.x, fPos.y);
        RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

        //GameObject touchedObject = hitInformation.transform.gameObject;

        if (hitInformation.collider != null)
        {
            Debug.Log("Hit info: " + hitInformation.collider.name);
        }

        //If not a joystick, then aim
        if (!hitInformation || !hitInformation.transform.gameObject.GetComponent<FixedJoystick>())
        {

            //Get the player to finger direction
            Vector3 aimDir = (fPos - transform.position).normalized;

            //Get angle in radians, then convert to degrees by multiplying
            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

            //Apply rotation
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
    }         
}
