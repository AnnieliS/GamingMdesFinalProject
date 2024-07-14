using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFloating : MonoBehaviour
{
    public float floatingAmplitude = 0.5f;
    public float floatingSpeed = 1f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float floatingAmount = Mathf.Sin(Time.time * floatingSpeed) * floatingAmplitude;
        Vector3 floatingOffset = new Vector3(0f, floatingAmount, 0f);

        transform.position = initialPosition + floatingOffset;
    }
}