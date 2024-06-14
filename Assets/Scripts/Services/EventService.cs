using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventService
{
    public static event Action OnPlayerTurnRight;
    public static void CallOnPlayerTurnRight()
        => OnPlayerTurnRight?.Invoke();

    public static event Action OnPlayerTurnLeft;
    public static void CallOnPlayerTurnLeft()
        => OnPlayerTurnLeft?.Invoke();
}
