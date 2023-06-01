using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoGun : Gun
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log("test");
        }
    }
}
