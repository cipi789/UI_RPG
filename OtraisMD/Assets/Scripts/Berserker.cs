using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int agressionGain = 10;
   public override int Attack()
    {
        agression += agressionGain;
        return ActiveWeapon.GetDamage() + agression / 10;
    }
}
