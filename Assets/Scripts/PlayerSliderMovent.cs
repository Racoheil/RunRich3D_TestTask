using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerSliderMovent : MonoBehaviour
{
    [SerializeField]
    private float _groundWidth = 10;

    [SerializeField]
    private float _horizontalSpeed = 50;

    [SerializeField]
    private float _verticalSpeed = 0.5f;

    private float _clampXValue = 4.5f;

    [SerializeField]
    private float _sensity = 5;

    private bool _isMoving;

    private Rigidbody _rigibody;
    private float _startValue;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void StartMoving()
    {
        _isMoving = true;
    }

    private void StopMoving()
    {
        _isMoving = false;
    }

    private void Update()
    {
        if (_isMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startValue = InputService.Instance.Slider.value;
            }

            transform.Translate(0, 0, _verticalSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (_isMoving)
        {
            if (Input.GetMouseButton(0))
            {
                var currentDelta = InputService.Instance.Slider.value - _startValue;
                var newPosition = 10 * currentDelta;
                transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(Mathf.Clamp(transform.position.x + newPosition * _sensity, -_clampXValue, _clampXValue),
                        transform.position.y,
                        transform.position.z), _horizontalSpeed * Time.deltaTime);

                _startValue = InputService.Instance.Slider.value;
            }
        }
    }
}
