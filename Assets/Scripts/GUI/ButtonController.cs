using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // 현재는 영웅 모집 버튼만 활성화 추후 나머지 추가
    [Header("Menu")]
    [SerializeField] private Button shopButton;
    [SerializeField] private Button shopPanelCloseButton;

    // 현재는 상점 패널만 추가
    [Header("Shop")]
    [SerializeField] private Image shopPanel;
    [SerializeField] private Image collectSinglePanel;
    [SerializeField] private GameObject singleUnitImageContainer;
    [SerializeField] private Image collectMultiPanel;
    [SerializeField] private GameObject multiUnitImageContainer;

    [Header("PartyEdit")]
    [SerializeField] private Image partyEditPanel;

    public void PressShopButton() // 영웅 모집 버튼
    {
        shopPanel.gameObject.SetActive(true);
    }

    public void PressSingleUnitCollectButton() // 영웅 1회 뽑기 패널 확인 버튼
    {
        foreach(Transform child in singleUnitImageContainer.transform)
        {
            Destroy(child.gameObject);
        }
        collectSinglePanel.gameObject.SetActive(false);
    }

    public void PressMultiUnitCollectButton() // 영웅 10회 뽑기 패널 확인 버튼
    {
        foreach (Transform child in multiUnitImageContainer.transform)
        {
            Destroy(child.gameObject);
        }
        collectMultiPanel.gameObject.SetActive(false);
    }

    public void PressShopPanelCloseButton() // 영웅 모집 패널 닫기 버튼
    {
        shopPanel.gameObject.SetActive(false);
    }

    public void PressPartyEditButton() // 공격대 편성 버튼
    {
        partyEditPanel.gameObject.SetActive(true);
    }

    public void PressClosePartyEditButton() // 공격대 편성 패널 닫기 버튼
    {
        partyEditPanel.gameObject.SetActive(false);
    }
}
