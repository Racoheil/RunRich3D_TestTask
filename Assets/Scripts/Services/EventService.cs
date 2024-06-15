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

    public static event Action<int> OnTakeMoney;
    public static void CallOnTakeMoney(int value)
        => OnTakeMoney?.Invoke(value);

    public static event Action<int> OnTakeAlcohol;
    public static void CallOnTakeAlcohol(int value)
        => OnTakeAlcohol?.Invoke(value);

    public static event Action<int> OnChangeModel;
    public static void CallOnChangeModel(int modelNumber)
        => OnChangeModel?.Invoke(modelNumber);

    public static event Action OnLevelWin;
    public static void CallOnLevelWin()
        => OnLevelWin?.Invoke();

    public static event Action OnLevelLose;
    public static void CallOnLevelLose()
        => OnLevelLose?.Invoke();

    public static event Action OnLevelStart;
    public static void CallOnLevelStart()
        => OnLevelStart?.Invoke();

    public static event Action<float> OnChangeCollectedMoney;
    public static void CallOnChangeCollectedMoney(float value)
        => OnChangeCollectedMoney?.Invoke(value);
}
