using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelChanger : MonoBehaviour
{
    [SerializeField] GameObject[] PlayerModels = new GameObject[5];

    private void OnEnable()
    {
        EventService.OnChangeModel += ChangeModel;
    }
    private void OnDisable()
    {
        EventService.OnChangeModel -= ChangeModel;

    }
    private void ChangeModel(int modelNumber)
    {
        foreach(GameObject model in PlayerModels)
        {
            model.SetActive(false);
        }
        PlayerModels[modelNumber].SetActive(true);
    }
}
