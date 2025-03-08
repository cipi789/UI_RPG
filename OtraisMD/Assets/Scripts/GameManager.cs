using UnityEngine;

public class GameManager : MonoBehaviour
{
     public Player player;
     public Enemy enemy;
     public Character character;
    void Start()
    {
        player.ReportHealth();
        Debug.Log(player.CharName);
        enemy.ReportHealth();
        character.ReportHealth();
    }

    void Update()
    {
        
    }
}
