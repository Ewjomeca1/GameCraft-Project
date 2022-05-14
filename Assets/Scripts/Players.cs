using UnityEngine;
using System.Collections.Generic;

public class Players : MonoBehaviour
{
    // Status System
    public int lifePoints = 25; // vida do jogador
    public int manaPoints = 1; // mana do jogador
    public int strenghtPoints = 2; // força imutavel do jogador
    public int currentStrenghtPoints = 2; // força atual do jogador

    public bool isPlaying = false; // variavel apenas para saber quem esta jogando

    // CoolDawnSystem && EffectiveSkillSystem.
    public int warPaintCoolDawn = 0; // Cooldawn da skill
    public int warPaintSkillEffective = 0; // tempo que a skill sera efetiva
   
   public int sharpnessSwordCoolDawn = 0; //Cooldawn da skill
   public int sharpnessSwordEffect = 0; // tempo que a skill sera efetiva
   public int aux; // variavel auxiliar para voltar a força ao normal apos o efeito de sharpness acabar

   public int restCoolDawn =0; // CoolDawn do descanso
    public void TakeDamage(int dmg)
    {
        lifePoints -= dmg;
        
    }
    public void EndYourTurn()
    {
        manaPoints++;   // adiciona mana a todo final de turno

        warPaintCDandEffect();        
        sharpnessSwordCDandEffect();
        ReturnValue();
    }
    void warPaintCDandEffect()  // Função para retornar a força ao valor original 
    {
        
        if(warPaintSkillEffective >0) warPaintSkillEffective--;

        if (warPaintCoolDawn >0 ) warPaintCoolDawn --;

        if (warPaintSkillEffective == 0) // caso queira retornar a força do war paint utilizar isso
        {
            
            //currentStrenghtPoints -= 2;
        }
    }
    public void ActiveWarPaint()    //Funçao para ativar a skill
    {
        manaPoints --;
        warPaintSkillEffective = 3; // Turnos que esse efeito vai ser efetivo
        currentStrenghtPoints += 2; // pontos de força que foram adicionados

        warPaintCoolDawn ++; // Adiciona ao CD
    }
    void sharpnessSwordCDandEffect()    // Função para retornar a força ao valor original 
    {
        
        if(sharpnessSwordEffect >0) sharpnessSwordEffect --;

        if(sharpnessSwordCoolDawn >0) sharpnessSwordCoolDawn --;

        if(sharpnessSwordEffect == 0)
        {
           currentStrenghtPoints -= aux;
           aux = 0;
           //ReturnValue();
        }
    }
    public void SharpnessActive() //  Funçao para ativar a skill
    {
        manaPoints -= 4; // diminui a mana

        sharpnessSwordEffect = 2; // seta os turnos de efetividade da skill
        aux = currentStrenghtPoints; // pega o ultimo valor de força e guarda ele para poder voltar pra ele quando o efeito acabar
        currentStrenghtPoints *= 2; // multiplica a força atual por 2

        sharpnessSwordCoolDawn += 2; // aumenta o CD da skill

        
    }
    void ReturnValue() // Caso os dois efeitos de Skills nao estiverem ativas retorna pro valor inicial de Dano
    {
        
        if(sharpnessSwordEffect == 0 && warPaintSkillEffective ==0)
        {
            //currentStrenghtPoints = strenghtPoints;
        }
    }

    public void Heal()
    {
        manaPoints --;
        if(currentStrenghtPoints >= 2)
        {
            currentStrenghtPoints -= 2;
            lifePoints += 4;
        }
    }

}
