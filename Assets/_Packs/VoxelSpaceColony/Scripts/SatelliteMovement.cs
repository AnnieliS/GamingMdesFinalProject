using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour
{
    public Transform targetPosition;
    public float movementDuration = 3f;
    public float floatingHeight = 0.5f;
    public float floatingSpeed = 1f;
    public float rotationSpeed = 30f;

    private Quaternion startRotation;
    private Vector3 startPosition;

    private void Start()
    {
        startRotation = transform.rotation;
        startPosition = transform.position;

        StartCoroutine(MoveCar(targetPosition.position, movementDuration));
    }

    private System.Collections.IEnumerator MoveCar(Vector3 target, float duration)
    {
        Vector3 floatingOffset = Vector3.zero;

        float elapsedTime = 0f;
        float randomDelay = Random.Range(0f, 1f);

        yield return new WaitForSeconds(randomDelay);

        while (elapsedTime < duration)
        {
            float floatingAmount = Mathf.Sin((elapsedTime + randomDelay) * floatingSpeed) * floatingHeight;
            floatingOffset.y = floatingAmount;

            transform.position = startPosition + floatingOffset + (target - startPosition) * (elapsedTime / duration);

            float rotationAngle = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAngle);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
        transform.rotation = startRotation;

        yield return new WaitForSeconds(1f);

        transform.position = startPosition;

        StartCoroutine(MoveCar(target, duration));
    }
}