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
