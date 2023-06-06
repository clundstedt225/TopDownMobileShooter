using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fields set at design time
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private Transform aimTransform;

    [SerializeField] private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);

        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            //Get angle in radians, then convert to degrees by multiplying
            float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;

            //Apply rotation
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
