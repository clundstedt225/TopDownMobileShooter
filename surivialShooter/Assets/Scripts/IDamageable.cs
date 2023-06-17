using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Can be damaged by player or game world
public interface IDamageable
{
    //Health property of game object
    float Health { get; set; }

    //Takes in amount to damage by
    void Damage(float amount);

    //Takes in amount to heal
    void Heal(float amount);
}
