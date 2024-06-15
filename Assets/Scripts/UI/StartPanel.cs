using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(true);
        InfoPanel.instance.DeactivatePanel();
    }
    public void StartLevel()
    {
        this.gameObject.SetActive(false);
        EventService.CallOnLevelStart();
        InfoPanel.instance.ActivatePanel();
    }
}
