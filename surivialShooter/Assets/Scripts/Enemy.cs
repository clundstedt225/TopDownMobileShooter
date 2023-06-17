using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health = 100;

    //How fast to move
    [SerializeField]
    private float moveSpeed = 2f;

    //How much health to damage player
    [SerializeField]
    private int attackDamage = 5;

    [SerializeField]
    private Transform healthBar;

    public float Health 
    { 
        get => health;
        set => health = value;
    }

    public void Damage(float amount)
    {
        //Safley handle damage using health manager
        health = HealthManager.HandleDamage(health, amount, healthBar);
    }

    public void Heal(float amount)
    {
        //Must have some damage to add health
        if (health < 100)
        {
            //prevent more than 100 health
            if ((health + amount) > 100)
            {
                health = 100;
            }
            else
            {
                health += amount;
            }

            //Update healthbar UI
            float val = (health / 100f);
            healthBar.localScale = new Vector3(val, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get vector to player

        //move in direction of player at movespeed

    }
}
