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

    private void OnEnable()
    {
        EventService.OnPlayerTurnLeft += TurnLeft;
        EventService.OnPlayerTurnRight += TurnRight;
    }
    void Start()
    {
        StartCoroutine(MovingForwardRoutine());
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) // Проверяем нажатие правой кнопки мыши
        {
            float moveHorizontal = Input.GetAxis("Mouse X"); // Получаем направление движения по горизонтали
            Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * _horizontalSpeed * Time.deltaTime; // Вычисляем вектор движения
            transform.Translate(movement); // Перемещаем игрока
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
        print(transform.rotation);
        transform.DORotate(new Vector3(0f, transform.eulerAngles.y + 90 , 0f), _rotateDuration);
        
    }

    private void TurnLeft()
    {
        print(transform.rotation);
        float newY = transform.rotation.y;
        print(newY);
        transform.DORotate(new Vector3(0f, transform.eulerAngles.y - 90, 0f), _rotateDuration);
    }

    private void OnDisable()
    {
        EventService.OnPlayerTurnLeft -= TurnLeft;
        EventService.OnPlayerTurnRight -= TurnRight;
    }


}
