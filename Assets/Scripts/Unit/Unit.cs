using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData unitData;
    public string unitName;
    public string unitRank;
    public string unitType;
    public float hp;
    public float power;
    public float defense;
    public float buffRate;
    public int reinforce;
    public int stack;
    private float reinforceRate = 100;

    
    public void InitStatus()
    {
        unitName = unitData.UnitName;
        unitRank = unitData.UnitRank;
        unitType = unitData.UnitType;
        hp = unitData.HP;
        power = unitData.Power;
        defense = unitData.Defense;
        buffRate = unitData.BuffRate;
        reinforce = unitData.Reinforce;
        stack = unitData.Stack;
    }

    private void UpdateReinforcedStatus()
    {
        hp += (reinforce / 10) * reinforceRate;
        power += (reinforce / 20) * reinforceRate;
        defense += (reinforce / 20) * reinforceRate;
    }

    public void AddStack()
    {
        stack++;
        if(stack >= 10)
        {
            if (stack >= 10)
            {
                stack -= 10;
                reinforce++;
                UpdateReinforcedStatus();
            }
        }
        Debug.Log($"{unitName} {unitRank} stack : {stack}");
    }
}
