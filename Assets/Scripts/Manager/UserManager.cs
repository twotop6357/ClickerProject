using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gem;
    [SerializeField] private TextMeshProUGUI partyPower;
    public int partyPoint;
    public bool isParty = false;
    
    public Unit initialUnit;

    private static UserManager _instance;
    public static UserManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<UserManager>();
                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<UserManager>();
                    singletonObject.name = typeof(UserManager).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    public List<Unit> ownedUnits = new List<Unit>();
    public Unit[] equippedUnits = new Unit[4];

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        if (equippedUnits == null)
        {
            for(int i = 0; i < equippedUnits.Length; i++)
            {
                equippedUnits[i] = new Unit();
            }
        }
    }

    private void Update()
    {
        if(isParty == true)
        {
            CalcPartyPower();
        }
    }

    private void CalcPartyPower()
    {
        float hp = 0;
        float power = 0;
        float defense = 0;

        foreach(Unit unit in equippedUnits)
        {
            if(unit != null)
            {
                hp += unit.hp;
                power += unit.power;
                defense += unit.defense;
                power = power + (power * unit.buffRate);
                defense = defense + (defense * unit.buffRate);
            }
        }
        
        partyPoint = (int)(hp + power + defense);
        partyPower.text = partyPoint.ToString();
    }
}
