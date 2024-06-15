using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholTrigger : MonoBehaviour
{
    private int _subtractedValue = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EventService.CallOnTakeAlcohol(_subtractedValue);
            this.gameObject.SetActive(false);
        }
    }
}
