using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : Character
{
    public TMP_Text healthText;
    public TMP_Text enemyHealthText;

    public Enemy enemy1;  // First enemy
    public Enemy enemy2;  // Second enemy
    private Enemy currentEnemy; // The active enemy

    public Button attackButton;
    public Button shieldButton;
    public Button healButton;
    public Button damageBuffButton;
    public GameObject PanelUI;
    public GameObject Win;
    public GameObject Lose;


    private bool shieldActive = false;
    private bool damageBuffActive = false;
    public float damageMultiplier = 1f;
    public int baseDamage = 10;

    void Start()
    {
        // Disable both enemies at start
        if (enemy1 != null) enemy1.gameObject.SetActive(false);
        if (enemy2 != null) enemy2.gameObject.SetActive(false);

        // Set first enemy as the current enemy
        if (enemy1 != null)
        {
            SetCurrentEnemy(enemy1);
        }

        // Assign button listeners
        attackButton?.onClick.AddListener(AttackButtonClicked);
        shieldButton?.onClick.AddListener(ToggleShield);
        healButton?.onClick.AddListener(ActivateHealingBuff);
        damageBuffButton?.onClick.AddListener(ActivateDamageBuff);
    }

    private void AttackButtonClicked()
    {
        if (currentEnemy == null) return;

        int damage = (int)(baseDamage * damageMultiplier);
        Debug.Log($"Player attacks for {damage} damage!");

        currentEnemy.TakeDamage(damage);
        UpdateEnemyUI();

        if (currentEnemy.health <= 0)
        {
            OnEnemyDefeated();
        }
        else
        {
            EnemyRetaliation();
        }
    }

    private void EnemyRetaliation()
    {
        if (currentEnemy == null) return;

        int retaliationDamage = 5;
        Debug.Log($"Enemy retaliates for {retaliationDamage} damage!");

        TakeDamage(retaliationDamage);
        UpdateUI();

        if (health <= 0)
        {
            health = 0;
            PanelUI.SetActive(false);
            Lose.SetActive(true);
            Debug.Log("Player is dead");
        }
    }

    private void ToggleShield()
    {
        shieldActive = !shieldActive;
        Debug.Log($"Shield is now {(shieldActive ? "ON" : "OFF")}");
    }

    public new void TakeDamage(int damage)
    {
        if (shieldActive)
        {
            // Reduce damage by 80% if the shield is active
            int reducedDamage = Mathf.RoundToInt(damage * 0.2f);
            Debug.Log($"Shield blocked 80% of the damage! Damage reduced to {reducedDamage}");

            // Apply the reduced damage to the player's health
            health -= reducedDamage;

            // Check if shield breaks (80% chance)
            float chance = Random.Range(0f, 1f); // Random chance between 0 and 1
            if (chance <= 0.5f)
            {
                shieldActive = false;
                Debug.Log("Shield is destroyed after absorbing the damage!");
            }
        }
        else
        {
            // Apply normal damage if shield is not active
            health -= damage;
        }

        // Ensure health doesn't go below zero
        health = Mathf.Max(health, 0);

        // Update UI
        UpdateUI();

        // Check if the player died
        if (health <= 0)
        {
            Debug.Log("Player died!");
            // You can trigger Game Over or death UI logic here
        }
    }
    private void ActivateHealingBuff()
    {
        health = Mathf.Min(health + 20, 100);
        Debug.Log("Healing buff activated! +20 health.");
        UpdateUI();
    }

    private void ActivateDamageBuff()
    {
        damageBuffActive = !damageBuffActive;
        damageMultiplier = damageBuffActive ? 3f : 1f;
        Debug.Log($"Damage Buff is now {(damageBuffActive ? "ACTIVE (x3 damage)" : "INACTIVE")}");
    }

    public void SetCurrentEnemy(Enemy enemy)
    {
        if (enemy == null) return;

        currentEnemy = enemy;
        currentEnemy.gameObject.SetActive(true);
        UpdateEnemyUI();
    }

    public void UpdateEnemyUI()
    {
        if (currentEnemy != null && enemyHealthText != null)
        {
            enemyHealthText.text = $"Enemy Health: {currentEnemy.health}";
        }
    }

    private void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = $"Health: {health}";
        }
    }

    public void OnEnemyDefeated()
    {
        if (currentEnemy != null)
        {
            currentEnemy.gameObject.SetActive(false);
        }

        if (currentEnemy == enemy1 && enemy2 != null)
        {
            SetCurrentEnemy(enemy2);
        }
        else if (currentEnemy == enemy2)
        {
            Debug.Log("You won the game!");
            Win.SetActive(true);
            PanelUI.SetActive(false);
        }
    }
}