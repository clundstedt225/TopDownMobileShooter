using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//This script rotates and aims the weapon transform

public class PlayerAimWeapon : MonoBehaviour
{

    [SerializeField] private Transform aimTransform;

    //UI raycast 
    [SerializeField] private GraphicRaycaster m_Raycaster; //On canvas
    [SerializeField] private EventSystem m_EventSystem; //In scene
    private PointerEventData m_PointerEventData;

    private void Start()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
    }

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

        //Set the Pointer Event Position to that of the touch position
        Vector2 touchPosWorld2D = new Vector2(fPos.x, fPos.y);
        m_PointerEventData.position = touchPosWorld2D;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            Debug.Log("Hit " + result.gameObject.name);
        }

        /*

        //2d raycast (UI may be different???)
        Vector2 touchPosWorld2D = new Vector2(fPos.x, fPos.y);
        RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
        
        //GameObject touchedObject = hitInformation.transform.gameObject;
        
        if (hitInformation.collider != null)
        {
            Debug.Log("Hit info: " + hitInformation.collider.name);
        
            if (hitInformation.transform.gameObject.GetComponent<FixedJoystick>())
            {
                Debug.Log("FOUND JOYSTICK!!!");
            }
        } 
        */

        /*
        //If not a joystick, then aim
        if (!hitInformation || !hitInformation.transform.gameObject.GetComponent<FixedJoystick>())
        {

            //Get the player to finger direction
            Vector3 aimDir = (fPos - transform.position).normalized;

            //Get angle in radians, then convert to degrees by multiplying
            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

            //Apply rotation
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        } */
    }
}
