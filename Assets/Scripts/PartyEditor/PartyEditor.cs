using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyEditor : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;
    [SerializeField] private Button fourthButton;

    [Header("Unit")]
    [SerializeField] private Image unitSelectPanel;
    [SerializeField] private GameObject unitContainer;

    private void Start()
    {
        firstButton.onClick.AddListener(() => PressPartyEditButton(firstButton));
        secondButton.onClick.AddListener(() => PressPartyEditButton(secondButton));
        thirdButton.onClick.AddListener(() => PressPartyEditButton(thirdButton));
        fourthButton.onClick.AddListener(() => PressPartyEditButton(fourthButton));
    }

    public void PressPartyEditButton(Button button)
    {
        CreateSelectPanel(button);
    }

    private void CreateSelectPanel(Button button)
    {
        foreach (Transform child in unitContainer.transform)
        {
            Destroy(child.gameObject);
        }
        List<Unit> list = UserManager.Instance.ownedUnits;
        for(int i = 0; i < list.Count; i++)
        {
            CreateButton(list[i], button);
        }
        unitSelectPanel.gameObject.SetActive(true);
    }

    private void CreateButton(Unit unit, Button btn)
    {
        GameObject go = new GameObject();
        go.AddComponent<Button>();
        RectTransform goRect = go.AddComponent<RectTransform>();
        goRect.sizeDelta = new Vector2(100, 100);
        GameObject button = Instantiate(go, unitContainer.transform);
        Instantiate(unit.unitData.IconImage, button.transform);
        Destroy(go);

        Button buttonComponent = button.GetComponent<Button>();
        if(buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(() => SelectUnit(unit, btn));
        }
    }

    private void SelectUnit(Unit unit, Button button)
    {
        // 전에 생성된 아이콘 이미지를 삭제하는 작업
        foreach(Transform child in button.transform)
        {
            Image imageComponent = child.GetComponent<Image>();
            if(imageComponent != null)
            {
                Destroy(child.gameObject);
            }
        }
        int index = 0;
        switch (button.name)
        {
            case "FirstMemberButton":
                index = 0; break;
            case "SecondMemberButton":
                index = 1; break;
            case "ThirdMemberButton":
                index = 2; break;
            case "FourthMemberButton":
                index = 3; break;
            default:
                Debug.Log("버튼 이름 오류");
                break;
        }
        Image image = Instantiate(unit.unitData.IconImage, button.transform);
        Debug.Log(index);
        if (UserManager.Instance.equippedUnits[index] != null)
        {
            UserManager.Instance.ownedUnits.Add(UserManager.Instance.equippedUnits[index]);
        }
        UserManager.Instance.equippedUnits[index] = unit;

        UserManager.Instance.isParty = true;
        int listIndex = UserManager.Instance.ownedUnits.IndexOf(unit);
        if(listIndex != -1)
        {
            UserManager.Instance.ownedUnits.RemoveAt(listIndex);
        }
        unitSelectPanel.gameObject.SetActive(false);
    }
}
