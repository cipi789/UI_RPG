using UnityEngine;
public class Berserker : Enemy
{
    [SerializeField] private int agressionGain = 10;

    public override int Attack()
    {
        agression += agressionGain;
        return ActiveWeapon.GetDamage() + agression / 10;
    }

    public void EnemyTurn(Player player)
    {
        if (player == null || IsDead()) return;

        int attackDamage = Attack();
        Debug.Log($"Berserker attacks {player.name} for {attackDamage} damage!");
        player.TakeDamage(attackDamage);

        // After attacking, call UpdateEnemyUI in Player to refresh the Berserker's health
        player.UpdateEnemyUI(); // Make sure this method is in Player to update enemy UI
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}