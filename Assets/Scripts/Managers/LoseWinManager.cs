using ButchersGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinManager : MonoBehaviour
{

    [SerializeField] private GameObject _winPanel;

    [SerializeField] private GameObject _losePanel;
    private void OnEnable()
    {
        EventService.OnLevelWin += DoOnWin;
        EventService.OnLevelLose += DoOnLose;
    }

    private void OnDisable()
    {
        EventService.OnLevelWin -= DoOnWin;
        EventService.OnLevelLose -= DoOnLose;
    }
    private void Start()
    {
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);
    }
    public void DoOnWin()
    {
        _winPanel.SetActive(true);
        _losePanel.SetActive(false);
    }

    public void DoOnLose()
    {
        _winPanel.SetActive(false);
        _losePanel.SetActive(true);
    }
}
