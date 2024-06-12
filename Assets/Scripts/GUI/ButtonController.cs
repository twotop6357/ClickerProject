using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // 현재는 영웅 모집 버튼만 활성화 추후 나머지 추가
    [SerializeField] private Button shopButton;
    [SerializeField] private Button shopPanelCloseButton;

    // 현재는 상점 패널만 추가
    [SerializeField] private Image shopPanel;

    public void PressShopButton()
    {
        shopPanel.gameObject.SetActive(true);
    }

    public void PressShopPanelCloseButton()
    {
        shopPanel.gameObject.SetActive(false);
    }
}
