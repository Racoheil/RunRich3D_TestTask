using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTrigger : MonoBehaviour
{
    private int _addingValue = 2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EventService.CallOnTakeMoney(_addingValue);
            this.gameObject.SetActive(false);
        }
    }
}
