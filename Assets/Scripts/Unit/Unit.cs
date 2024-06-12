using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData unitData;
    private string unitName;
    private string unitRank;
    private string unitType;
    private float hp;
    private float power;
    private float defense;
    private float buffRate;
    private int reinforce;

    private void Start()
    {
        if(unitData != null)
        {
            // Init Status
            unitName = unitData.UnitName;
            unitRank = unitData.UnitRank;
            unitType = unitData.UnitType;
            hp = unitData.HP;
            power = unitData.Power;
            defense = unitData.Defense;
            buffRate = unitData.BuffRate;
            reinforce = unitData.Reinforce;

            // Reinforced Status
            hp += reinforce * (hp / 10);
            power += reinforce * (power / 10);
            defense += reinforce * (defense / 10);
            buffRate += reinforce * (reinforce / 10);
        }
    }
}
