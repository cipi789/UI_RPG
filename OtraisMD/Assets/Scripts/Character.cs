using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour

{

    public int health;

    [SerializeField] private Weapon activeWeapon;

    public Weapon ActiveWeapon

    {

        get { return activeWeapon; }
        set { activeWeapon = value; } // Now you can assign a new weapon

    }

    public virtual int Attack()

    {

        if (activeWeapon == null)

        {

            Debug.LogWarning($"{name} does not have an active weapon!");

            return 0; // Return 0 damage if there's no weapon

        }

        return activeWeapon.GetDamage();

    }

    public virtual void TakeDamage(int damage)

    {

        Debug.Log($"{name} health before hit: {health}");

        health -= damage;

        // Ensure health doesn't go below zero

        health = Mathf.Max(health, 0);

        Debug.Log($"{name} health after hit: {health}");

    }

    public void TakeDamage(Weapon weapon)

    {

        if (weapon == null)

        {

            Debug.LogWarning($"{name} was hit by an invalid weapon!");

            return; // Exit if weapon is null

        }

        Debug.Log($"{name} health before hit: {health}");

        // Calculate damage from the weapon

        int damage = weapon.GetDamage();

        health -= damage;

        // Apply weapon effects

        weapon.ApplyEffect(this);

        // Ensure health doesn't go below zero

        health = Mathf.Max(health, 0);

        Debug.Log($"{name} was hit by {weapon.name} for {damage} damage. Health after hit: {health}");

    }

}
