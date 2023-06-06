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
        //Only run on first frame of touch
        if (touch.phase == TouchPhase.Began)
        {
            //Play sound

            //Convert screen coords to world position
            Vector3 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);
            fingerPos.z = 0f;

            //Fire raycast
            RaycastHit2D hit = Physics2D.Raycast(barrelPos.position, barrelPos.right);

            if (hit.collider)
            {
                Debug.Log("Bullet hit a wild " + hit.transform.name);
                barrelPos.GetComponent<LineRenderer>().SetPosition(0, barrelPos.position);
                barrelPos.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            } else
            {
                Debug.Log("Bullet hit nothing");
                barrelPos.GetComponent<LineRenderer>().SetPosition(0, barrelPos.position);
                barrelPos.GetComponent<LineRenderer>().SetPosition(1, barrelPos.right * 500);
            }

            //Show visuals
            StartCoroutine(lineFlicker());
        }
    }

    IEnumerator lineFlicker()
    {
        barrelPos.GetComponent<LineRenderer>().enabled = true;
        yield return new WaitForSeconds(0.05f);
        barrelPos.GetComponent<LineRenderer>().enabled = false;
    }
}
