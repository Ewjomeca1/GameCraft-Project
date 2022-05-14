using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public enum BattleSystem { p1Playing , p2Playing } //  Enum para verificar qual jogador esta jogando
    public BattleSystem battle; // Declaração desse Enum
    public Players player1; // Pega a referencia de todos os valores do player 1
    public Players player2; // Pega a referencia de todos os valores do player 1
    
    int controllerVariable = 0; // Variavel feita para controlar cada final de turno para aumentar a mana e zerar o CD
    
    
    public BattleHUD playerOneHUD;
    public BattleHUD playerTwoHUD;
    
    public void Start()
    {
        battle = BattleSystem.p1Playing;
        playerOneHUD.SetHUD(player1);
        playerTwoHUD.SetHUD(player2);
        
    }
    public void OnAttackButtonPlayerOnePressed() // Ataque do Player 1
    {
        if(battle == BattleSystem.p1Playing)
        {
            player2.TakeDamage(player1.currentStrenghtPoints);
            
            ChangeStatePlayerOne();
        }
    }
    public void OnAttackButtonPlayerTwoPressed() // Ataque do Player 2
    {
        if(battle == BattleSystem.p2Playing)
        {
            player1.TakeDamage(player2.currentStrenghtPoints);
            
            ChangeStatePlayerTwo();
        }
    }

    public void OnMeditationButtonPressedOne() // Meditação do Player 1
    {
        if(battle == BattleSystem.p1Playing)
        {
            player1.manaPoints += 2;
            ChangeStatePlayerOne();
        }
    }
    public void OnMeditationButtonPressedTwo() // Meditação do Player 2
    {
        if(battle == BattleSystem.p2Playing)
        {
            player2.manaPoints += 2;
            ChangeStatePlayerTwo();
        }
    }

    public void OnWarPaintButtonPressedOne()    // Skill de aumentar a força em 2
    {
        if(battle == BattleSystem.p1Playing)
        {
            if(player1.manaPoints >=1 && player1.warPaintCoolDawn == 0)
            {
               player1.ActiveWarPaint();
                ChangeStatePlayerOne(); // Muda pro Player2
            }
            else
            {
                Debug.Log("AÇÃO INVALIDA");
            }
        }
    }
    public void OnWarPaintButtonPressedTwo()    // Skill de aumentar a força em 2
    {
        if(battle == BattleSystem.p2Playing)
        {
            if(player2.manaPoints >=1 && player2.warPaintCoolDawn == 0)
            {
                player2.ActiveWarPaint();
                ChangeStatePlayerTwo(); // Muda pro Player1
            }
            else
            {
                Debug.Log("AÇÃO INVALIDA");
            }
        }
    }

    public void OnSharpnessSwordPressedOne()    // Skill de Afiar a arma
    {
        if(battle == BattleSystem.p1Playing)
        {
            if(player1.manaPoints >= 4 && player1.sharpnessSwordCoolDawn ==0)
            {
                player1.SharpnessActive();
                ChangeStatePlayerOne(); // Muda pro Player2
            }
            else
            {
                Debug.Log("Ação Invalida");
            }
        }
    }
    public void OnSharpnessSwordPressedTwo()    // Skill de Afiar a arma
    {
        if(battle == BattleSystem.p2Playing)
        {
            if(player2.manaPoints >= 4 && player2.sharpnessSwordCoolDawn ==0)
            {
                player2.SharpnessActive();
                ChangeStatePlayerTwo(); // Muda pro Player1
            }
            else
            {
                Debug.Log("Ação Invalida");
            }
        }
    }
    public void OnRestPressedOne()  // Quando o player 1 descansar
    {
        if(battle == BattleSystem.p1Playing)
        {
            if(player1.manaPoints >= 1 && player1.restCoolDawn == 0)
            {
                player1.Heal();
                ChangeStatePlayerOne();
            }
        }
    }
    public void OnRestPressedTwo() // Quando o player 2 descansar
    {
        

        if(battle == BattleSystem.p2Playing)
        {
            if(player2.manaPoints >= 1 && player2.restCoolDawn ==0)
            {
                player2.Heal();
                ChangeStatePlayerTwo();
            }
        }
    }
///////////////////////////// Mudanças de Estados Abaixo//////////////////////


    public void ChangeStatePlayerOne() //  Troca o turno para o Player 2
    {
        battle = BattleSystem.p2Playing;
        player2.isPlaying = true;
        player1.isPlaying = false;

        playerOneHUD.SetHUD(player1);
        playerTwoHUD.SetHUD(player2);
        GameController();
    }
    public void ChangeStatePlayerTwo() //  Troca o turno para o Player 1
    {
        battle = BattleSystem.p1Playing;
        player1.isPlaying = true;
        player2.isPlaying = false;

        playerOneHUD.SetHUD(player1);
        playerTwoHUD.SetHUD(player2); 
        GameController();
    }
    void GameController()
    {
        controllerVariable ++;
        if(controllerVariable == 2)
        {
            controllerVariable =0; // variavel de controle para acabar o turno

            player1.EndYourTurn(); // Termina seu turno
            player1.isPlaying = false;
            playerOneHUD.SetHUD(player1); // Atualiza Status

            player2.EndYourTurn(); 
            player2.isPlaying = false;
            playerTwoHUD.SetHUD(player2); 
        }
    }
    
}
