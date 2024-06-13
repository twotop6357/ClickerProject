using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // ����� ���� ���� ��ư�� Ȱ��ȭ ���� ������ �߰�
    [Header("Menu")]
    [SerializeField] private Button shopButton;
    [SerializeField] private Button shopPanelCloseButton;

    // ����� ���� �гθ� �߰�
    [Header("Shop")]
    [SerializeField] private Image shopPanel;
    [SerializeField] private Image collectSinglePanel;
    [SerializeField] private GameObject singleUnitImageContainer;
    [SerializeField] private Image collectMultiPanel;
    [SerializeField] private GameObject multiUnitImageContainer;

    [Header("PartyEdit")]
    [SerializeField] private Image partyEditPanel;

    public void PressShopButton() // ���� ���� ��ư
    {
        shopPanel.gameObject.SetActive(true);
    }

    public void PressSingleUnitCollectButton() // ���� 1ȸ �̱� �г� Ȯ�� ��ư
    {
        foreach(Transform child in singleUnitImageContainer.transform)
        {
            Destroy(child.gameObject);
        }
        collectSinglePanel.gameObject.SetActive(false);
    }

    public void PressMultiUnitCollectButton() // ���� 10ȸ �̱� �г� Ȯ�� ��ư
    {
        foreach (Transform child in multiUnitImageContainer.transform)
        {
            Destroy(child.gameObject);
        }
        collectMultiPanel.gameObject.SetActive(false);
    }

    public void PressShopPanelCloseButton() // ���� ���� �г� �ݱ� ��ư
    {
        shopPanel.gameObject.SetActive(false);
    }

    public void PressPartyEditButton() // ���ݴ� �� ��ư
    {
        partyEditPanel.gameObject.SetActive(true);
    }

    public void PressClosePartyEditButton() // ���ݴ� �� �г� �ݱ� ��ư
    {
        partyEditPanel.gameObject.SetActive(false);
    }
}
