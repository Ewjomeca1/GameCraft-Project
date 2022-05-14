using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text playerTurn;
    
    
    public Text playerHealth;
    public Text playerMana;
    public Text playerStrenght;

    public Text warPaintCD;
    public Text sharpnessCD;
    public Text restCD;

    public void SetHUD(Players player)
    {
        if(player.isPlaying)
        {
            playerTurn.text = "Player that is Playing = " + player;
        }

        playerHealth.text ="Life = " +  player.lifePoints.ToString();
        playerMana.text = "Mana = " + player.manaPoints.ToString();
        playerStrenght.text = "Strenght = " + player.currentStrenghtPoints.ToString();

        warPaintCD.text = player.warPaintCoolDawn.ToString();
        sharpnessCD.text = player.sharpnessSwordCoolDawn.ToString();
        restCD.text = player.restCoolDawn.ToString();
    }
}
