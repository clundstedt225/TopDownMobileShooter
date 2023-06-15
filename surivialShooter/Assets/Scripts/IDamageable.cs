using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Can be damaged by player or game world
public interface IDamageable
{
    int health { get; set; }

    //Takes in amount to damage by
    void Damage(int amount);

    //Takes in amount to heal
    void Heal(int amount);
}
