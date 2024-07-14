using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float timeBetweenRotations = 2f;
    public Vector3 minRotationAngles = new Vector3(0f, -50f, -0f);
    public Vector3 maxRotationAngles = new Vector3(0f, 50f, 0f);

    private Vector3 currentRotation;
    private Vector3 targetRotation;
    private bool isRotating = false;

    private void Start()
    {
        currentRotation = transform.localRotation.eulerAngles;
        targetRotation = currentRotation;
    }

    private void Update()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTourelle());
        }
    }

    private IEnumerator RotateTourelle()
    {
        isRotating = true;

        // Set the target rotation within the specified ranges for each axis
        float targetXRotation = Random.Range(minRotationAngles.x, maxRotationAngles.x);
        float targetYRotation = Random.Range(minRotationAngles.y, maxRotationAngles.y);
        float targetZRotation = Random.Range(minRotationAngles.z, maxRotationAngles.z);
        targetRotation = new Vector3(targetXRotation, targetYRotation, targetZRotation);

        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(targetRotation);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / timeBetweenRotations;
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }

        isRotating = false;
    }
}