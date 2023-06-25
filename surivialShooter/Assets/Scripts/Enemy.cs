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

    //Whats the closest the enemy should get?
    [SerializeField]
    private float maxDistance = 1f;

    //How much health to damage player
    [SerializeField]
    private int attackDamage = 5;

    [SerializeField]
    private Transform healthBar;

    [SerializeField]
    private Rigidbody2D rb;

    public float Health 
    { 
        get => health;
        set => health = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //Health check
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        //get direction to player as vector
        Vector3 pPos = GameManager.Instance.playerRef.position;
        Vector3 playerDir = (pPos - gameObject.transform.position).normalized;

        //Implicit conversion to vec2 for 2D gameplay
        Vector2 playerDir2D = playerDir;

        //Stop if within attack range
        if (Vector3.Distance(gameObject.transform.position, pPos) > maxDistance) {
            //move in direction of player at movespeed
            rb.velocity = playerDir2D * moveSpeed;
        } else {
            rb.velocity = Vector2.zero;
        }
    }

    public void Damage(float amount)
    {
        //Returns health value after damage is applie
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
}
