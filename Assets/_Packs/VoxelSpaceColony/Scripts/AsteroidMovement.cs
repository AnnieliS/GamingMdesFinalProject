using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float rotationSpeed = 30f; // Vitesse de rotation de l'astéroïde
    public float floatSpeed = 1f; // Vitesse de flottement de l'astéroïde
    public float floatAmplitude = 0.5f; // Amplitude de flottement de l'astéroïde

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Faire tourner l'astéroïde sur lui-même
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Faire flotter l'astéroïde en utilisant une fonction sinus pour créer un mouvement fluide
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = newPosition;
    }
}