using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//This script rotates and aims the weapon transform

public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;

    //List of touch ids to ignore???
    List<int> IdsToIgnore = new List<int>();

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.touchCount);

        int tapCount = Input.touchCount;

        //Loop through all active screen touches
        for (var i = 0; i < tapCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            //On begin, should check for ignore 
            if (touch.phase == TouchPhase.Began) {
                IgnoreCheck(touch.fingerId);
            }

            //Handle aiming for finger id's not in ignore list
            if (!IdsToIgnore.Contains(touch.fingerId))
            {
                HandleAiming(touch);
            }

            //Remove id from list if being ignored
            if (touch.phase == TouchPhase.Ended)
            {
                if (IdsToIgnore.Contains(touch.fingerId))
                {
                    IdsToIgnore.Remove(touch.fingerId);
                }
            }
        }
    }

    void HandleAiming(Touch touch)
    {
        Vector3 fPos = Camera.main.ScreenToWorldPoint(touch.position);
        fPos.z = 0f;

        //Get the player to finger direction
        Vector3 aimDir = (fPos - transform.position).normalized;

        //Get angle in radians, then convert to degrees by multiplying
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

        //Apply rotation
        aimTransform.eulerAngles = new Vector3(0, 0, angle);      
    }

    //Should this finger id be ignored by game logic
    void IgnoreCheck(int id)
    {
        //Check if current touch qualifies to be ignored
        if (EventSystem.current.IsPointerOverGameObject(id))
        {
            //Add if not already in list
            if (!IdsToIgnore.Contains(id))
            {
                IdsToIgnore.Add(id);
            }
        }
    }
}
