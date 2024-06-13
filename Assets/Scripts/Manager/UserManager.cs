using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
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
    public List<Unit> equippedUnits = new List<Unit>();

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
    }
}
