using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    [SerializeField]
    private TMP_Text playerName, playerHealth,
        enemyName, enemyHealth;

    void Start()
    {
        int playerDamage = player.Attack();
        enemy.TakeDamage(playerDamage);

        int enemyDamage= enemy.Attack();
        player.TakeDamage(enemyDamage);
     
       
    }

  public void DoRound()
    {
        //int playerDamage = player.Attack();
        //enemy.TakeDamage(playerDamage);
        enemy.TakeDamage(player.ActiveWeapon);
        int enemyDamage = enemy.Attack();
        player.TakeDamage(enemyDamage);
        RefreshUI();

    }
    private void RefreshUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        playerHealth.text = "health: " + player.health.ToString();
        enemyHealth.text = "health: " + enemy.health.ToString();
    }
}
