using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HealthManager
{

    //Safley handle damage dealing to game objects
    public static float HandleDamage(float hValue, float amount, Transform healthBar)
    {
        float finalValue = hValue;

        //Must have some health to deal damage
        if (finalValue > 0)
        {
            //prevent less than 0 health
            if ((finalValue - amount) < 0)
            {
                finalValue = 0;
            }
            else
            {
                finalValue -= amount;
            }

            //Update healthbar UI
            healthBar.localScale = new Vector3((finalValue / 100f), 1f);
        }

        return finalValue;
    }

    public static float HandleHealth()
    {
        float finalValue = 0;

        //TODO: implement functions logic

        return finalValue;
    }
}
