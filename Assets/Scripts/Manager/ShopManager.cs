using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<Unit> units = new List<Unit>();

    [Header("UI")]
    [SerializeField] private Image collectSinglePanel;
    [SerializeField] private GameObject singleUnitImageContainer;
    [SerializeField] private Image collectMultiPanel;
    [SerializeField] private GameObject multiUnitImageContainer;

    private float GetWeightByRank(string rank) // 유닛의 등급 별 등장 확률 가중치를 받아오는 메서드
    {
        switch(rank)
        {
            case "일반":
                return 55.0f;
            case "레어":
                return 30.0f;
            case "전설":
                return 15.0f;
            default:
                return 1.0f;
        }
    }

    public void SingleDraw()
    {
        if(UserManager.Instance.gemRate >= 250) 
        {
            UserManager.Instance.gemRate -= 250;
            Unit drawnUnit = DrawSingleUnit();

            int index = UserManager.Instance.ownedUnits.IndexOf(drawnUnit);
            if (index != -1)
            {
                UserManager.Instance.ownedUnits[index].AddStack();
            }
            else
            {
                drawnUnit.InitStatus();
                UserManager.Instance.ownedUnits.Add(drawnUnit);
            }

            Image image = Instantiate(drawnUnit.unitData.IconImage, singleUnitImageContainer.transform);
            image.transform.localScale = new Vector2(3, 3);
            collectSinglePanel.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("젬이 부족합니다.");
        }
        
    }

    public void MultiDraw()
    {
        if(UserManager.Instance.gemRate >= 2500)
        {
            UserManager.Instance.gemRate -= 2500;
            List<Unit> drawnUnits = new List<Unit>();
            drawnUnits = DrawUnits();
            for (int j = 0; j < drawnUnits.Count; j++)
            {
                int index = UserManager.Instance.ownedUnits.IndexOf(drawnUnits[j]);
                if (index != -1)
                {
                    UserManager.Instance.ownedUnits[index].AddStack();
                    Debug.Log(UserManager.Instance.ownedUnits[index].stack);
                }
                else
                {
                    drawnUnits[j].InitStatus();
                    UserManager.Instance.ownedUnits.Add(drawnUnits[j]);
                }
                // UserManager.Instance.ownedUnits.Add(drawnUnits[j]);
                Instantiate(drawnUnits[j].unitData.IconImage, multiUnitImageContainer.transform);
                collectMultiPanel.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("젬이 부족합니다.");
        }
    }

    public Unit DrawSingleUnit()
    {
        List<float> weights = new List<float>();
        foreach(Unit unit in units)
        {
            float weight = GetWeightByRank(unit.unitData.UnitRank);
            weights.Add(weight);
        }

        float totalWeight = 0;
        foreach(float weight in weights)
        {
            totalWeight += weight;
        }

        float randomValue = Random.Range(0, totalWeight);

        float cumulativeWeight = 0;
        for(int i = 0; i < units.Count; i++)
        {
            cumulativeWeight += weights[i];
            if(randomValue <= cumulativeWeight)
            {
                return units[i];
            }
        }
        return null;
    }

    public List<Unit> DrawUnits()
    {
        List<Unit> drawnUnits = new List<Unit>();
        for(int i = 0; i < 10;  i++)
        {
            Unit unit = DrawSingleUnit();
            drawnUnits.Add(unit);
        }
        return drawnUnits;
    }
}
