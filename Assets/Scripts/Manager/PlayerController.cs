using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset inputActions;
    public InputAction clickAction;
    public TextMeshProUGUI hitText;
    private int partyPoint;
    private int score;
    private int hit;
    private int gem;

    public TextMeshProUGUI endPanelScoreText;
    public TextMeshProUGUI endPanelGemText;

    private void OnEnable()
    {
        var gamePlayActionMap = inputActions.FindActionMap("Player");
        clickAction = gamePlayActionMap.FindAction("Click");

        clickAction.performed += OnClickPerformed;

        clickAction.Enable();

        partyPoint = UserManager.Instance.partyPoint;
        score = 0;
        hit = 0;
    }

    private void OnDisable()
    {
        clickAction.performed -= OnClickPerformed;
        clickAction.Disable();
    }

    private void Update()
    {
        hitText.text = hit.ToString();
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        hit++;
    }

    public void GameEnd()
    {
        score = hit * partyPoint / 1000;
        gem = score / 10;
        Debug.Log($"{score}, {gem}");
        endPanelScoreText.text = score.ToString();
        endPanelGemText.text = gem.ToString();
        UserManager.Instance.gemRate += score / 10;
    }
}
