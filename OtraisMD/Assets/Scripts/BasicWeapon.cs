using UnityEngine;

public class BasicWeapon : Weapon

{

    public int damage; // Damage caused by the weapon

    public int Attack()

    {

        return damage; // Return the weapon's damage

    }

    public override void ApplyEffect(Character character)

    {

        // Apply the weapon's damage effect to the character

        character.TakeDamage(damage);

        // Log the effect

        Debug.Log($"{character.name} took {damage} damage from {name}");

    }

}
