using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // ����� ���� ���� ��ư�� Ȱ��ȭ ���� ������ �߰�
    [SerializeField] private Button shopButton;
    [SerializeField] private Button shopPanelCloseButton;

    // ����� ���� �гθ� �߰�
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
