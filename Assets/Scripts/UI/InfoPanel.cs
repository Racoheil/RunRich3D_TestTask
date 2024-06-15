using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _collectedMoneyCount;

    private int _startCount = 0;
    private void OnEnable()
    {
        EventService.OnChangeCollectedMoney += ChangeCollectedMoneyText;
    }
    private void OnDisable()
    {
        EventService.OnChangeCollectedMoney -= ChangeCollectedMoneyText;
    }

    public static InfoPanel instance;

    private void Awake()
    {
        instance = this;
        _collectedMoneyCount.text = _startCount.ToString();
    }

    public void ActivatePanel()
    {
        this.gameObject.SetActive(true);
    }
    public void DeactivatePanel()
    {
        this.gameObject.SetActive(false);
    }
    public void ChangeCollectedMoneyText(float newValue)
    {
        _collectedMoneyCount.text = newValue.ToString();
    }
}
