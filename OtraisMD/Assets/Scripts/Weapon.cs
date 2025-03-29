using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int minDamage;  // Minimum damage value
    [SerializeField] private int maxDamage;  // Maximum damage value

    public int GetDamage()
    {
        // Generates a random damage value between minDamage and maxDamage (inclusive)
        return Random.Range(minDamage, maxDamage + 1);
    }

    public abstract void ApplyEffect(Character character);
}