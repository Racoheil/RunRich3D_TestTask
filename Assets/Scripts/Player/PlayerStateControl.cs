using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateControl : MonoBehaviour
{
    private float _currentValue = 10f;

    private float _minValue = 1f;

    private float _maxValue = 100f;

    private float _addingValue = 2f;

    private float _subtractedValue = 20f;

    private int _currentState = 0;

    [SerializeField] private TMP_Text _stateText;

    private string[] _playerStates;

    [SerializeField] private Image _bar;

    private void OnEnable()
    {
        EventService.OnTakeMoney += IncreaseValue;
        EventService.OnTakeAlcohol += DecreaseValue;
    }
    private void Awake()
    {
        _playerStates = new string[5]
        {
        "¡ŒÃ∆",
        "¡≈ƒÕ€…",
        "œ»∆ŒÕ",
        "¡Œ√¿◊",
        "¡Œ——"
        };

        SetStartState();
    }
    private void SetStartState()
    {
        SetState();
        _bar.fillAmount = _currentValue / 100;
    }
    private void IncreaseValue(int _value)
    {
        print(_currentValue);
        _currentValue += _value;
        _bar.fillAmount = _currentValue/100;
        SetState();

        EventService.CallOnChangeCollectedMoney(_currentValue);
    }
    private void DecreaseValue(int _value)
    {
        print(_currentValue);
        
        _currentValue -= _value;
        _bar.fillAmount = _currentValue / 100;
        SetState();

        if (_currentValue < _minValue)
        {
            EventService.CallOnLevelLose();
            return;
        }

        EventService.CallOnChangeCollectedMoney(_currentValue);
    }
    private void SetState()
    {
        if (_currentValue <= 25)
        {
            _currentState = 0;
            _stateText.text = _playerStates[_currentState];

            EventService.CallOnChangeModel(_currentState);
        }
        else if(_currentValue > 25 && _currentValue <= 50)
        {
            _currentState = 1;
            _stateText.text = _playerStates[_currentState];

            EventService.CallOnChangeModel(_currentState);
        }
        else if (_currentValue > 50 && _currentValue <= 75)
        {
            _currentState = 2;
            _stateText.text = _playerStates[_currentState];

            EventService.CallOnChangeModel(_currentState);
        }
        else if (_currentValue > 75 && _currentValue <= 99)
        {
            _currentState = 3;
            _stateText.text = _playerStates[_currentState];

            EventService.CallOnChangeModel(_currentState);
        }
        else if (_currentValue > 99)
        {
            _currentState = 4;
            _stateText.text = _playerStates[_currentState];

            EventService.CallOnChangeModel(_currentState);
        }
    }
    private void OnDisable()
    {
        EventService.OnTakeMoney -= IncreaseValue;
        EventService.OnTakeAlcohol -= DecreaseValue;
    }
}
