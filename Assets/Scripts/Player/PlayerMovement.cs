using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 30;

    [SerializeField] private float _verticalSpeed = 5f;

    private bool _isMoving = true;

    private float _rotateDuration = 1.5f;

    private float _turnDelay = 1f;

    private void OnEnable()
    {
        EventService.OnPlayerTurnLeft += TurnLeft;
        EventService.OnPlayerTurnRight += TurnRight;
        EventService.OnLevelLose += FreezePlayer;
        EventService.OnLevelWin += FreezePlayer;
        EventService.OnLevelStart += ActivatePlayer;
    }
    void Start()
    {
        FreezePlayer();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && _isMoving) 
        {
            float moveHorizontal = Input.GetAxis("Mouse X");
            Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * _horizontalSpeed * Time.deltaTime; 
            transform.Translate(movement); 
        }
    }
    private IEnumerator MovingForwardRoutine()
    {
        while (_isMoving)
        {
            transform.Translate(Vector3.forward * _verticalSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private void TurnRight()
    {
        StartCoroutine(DelayRoutine());
        transform.DORotate(new Vector3(0f, transform.eulerAngles.y + 90 , 0f), _rotateDuration);
    }

    private void TurnLeft()
    {
        StartCoroutine(DelayRoutine());
        transform.DORotate(new Vector3(0f, transform.eulerAngles.y - 90, 0f), _rotateDuration);
    }

    IEnumerator DelayRoutine() 
    {
        yield return new WaitForSecondsRealtime(_turnDelay);
    }

    private void FreezePlayer()
    {
        _isMoving = false;
    }
    private void ActivatePlayer()
    {
        _isMoving = true;
        StartCoroutine(MovingForwardRoutine());
    }

    private void OnDisable()
    {
        EventService.OnPlayerTurnLeft -= TurnLeft;
        EventService.OnPlayerTurnRight -= TurnRight;
        EventService.OnLevelLose -= FreezePlayer;
        EventService.OnLevelWin -= FreezePlayer;
        EventService.OnLevelStart -= ActivatePlayer;
    }


}
