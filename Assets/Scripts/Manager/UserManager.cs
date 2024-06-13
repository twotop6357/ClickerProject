using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
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
}
