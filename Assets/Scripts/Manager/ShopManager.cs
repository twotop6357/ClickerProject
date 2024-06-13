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
    //[SerializeField] private Image collectMultiPanel;

    private float GetWeightByRank(string rank) // 유닛의 등급 별 등장 확률 가중치를 받아오는 메서드
    {
        switch(rank)
        {
            case "일반":
                return 70.0f;
            case "레어":
                return 25.0f;
            case "전설":
                return 5.0f;
            default:
                return 1.0f;
        }
    }

    public void SingleDraw()
    {
        Unit drawnUnit = DrawSingleUnit();
        UserManager.Instance.ownedUnits.Add(drawnUnit);
        Image image = Instantiate(drawnUnit.unitData.IconImage, singleUnitImageContainer.transform);
        image.transform.localScale = new Vector2(3, 3);
        collectSinglePanel.gameObject.SetActive(true);
        // 확인용
        //Debug.Log($"{drawnUnit.unitData.UnitRank}, {drawnUnit.unitData.UnitName} 유닛이 리스트에 추가되었습니다.");
        // 확인용
    }

    public void MultiDraw()
    {
        List<Unit> drawnUnits = new List<Unit>();
        drawnUnits = DrawUnits();
        for (int j = 0; j < drawnUnits.Count; j++)
        {
            UserManager.Instance.ownedUnits.Add(drawnUnits[j]);
            Instantiate(drawnUnits[j].unitData.IconImage, multiUnitImageContainer.transform);
            collectMultiPanel.gameObject.SetActive(true);
        }
        // 확인용
        //    Debug.Log($"{drawnUnits[j].unitData.UnitRank}, {drawnUnits[j].unitData.UnitName} 유닛이 리스트에 추가되었습니다.");
        // 확인용
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
