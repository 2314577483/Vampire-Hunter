using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(HealthBar))]
//RequireComponent(typoeof(HealthBar))
public class PlayerCharacter : MonoBehaviour
{
    // For tweaking --------------
    public float baseDamage = 1;
    public float baseSpeed = 10f;
    public int maxWeapons = 3;
    public int maxItems = 3;
    public float baseHealth = 100;
    // ---------------------------

    protected float damage;
    protected float health;
    protected HealthBar playerHealthBar;

    protected List<Weapon> weapons;
    // protected List<Item> items;
    protected PlayerController playerController;

    void Start() {
        playerController = GetComponent<PlayerController>();
        playerHealthBar = GetComponent<HealthBar>();
        health = baseHealth;
        playerHealthBar.maxHealth = baseHealth;
        playerHealthBar.health = health;

    }

    void Update(){
        //debug: making sure bar is updated (it doesn't)
        TakeDamage(0.5f);
    }

    public float GetPlayerDamage() {
        return damage;
    }

    public void TakeDamage(float damage){
        if (damage > health) damage = health;
        
        health -= damage;

        // update health bar
        Debug.Log("PC calling HB::TakeDamage.");
        playerHealthBar.TakeDamage(damage);

        if (health <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
    }

}
