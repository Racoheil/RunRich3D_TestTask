using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private enum platformTypes
    {
        NoTurning,
        LeftTurning,
        RightTurning
    }
    [SerializeField] private platformTypes _currentPlatformType;
    private void OnCollisionEnter(Collision collision)
    {
        if (_currentPlatformType == platformTypes.NoTurning) return;
        if(collision.transform.tag == "Player")
        {
            switch (_currentPlatformType)
            {
                case platformTypes.LeftTurning:

                    EventService.CallOnPlayerTurnLeft();
                    break;

                case platformTypes.RightTurning:

                    EventService.CallOnPlayerTurnRight();
                    break;

                default:
                    break;
        }
        }

    }
}
