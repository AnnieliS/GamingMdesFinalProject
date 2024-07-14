using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;  // Vitesse de rotation du spotlight
    public float minRotationTime = 1f;  // Temps minimum entre chaque rotation
    public float maxRotationTime = 2f;  // Temps maximum entre chaque rotation

    private Quaternion targetRotation;  // Rotation cible actuelle
    private float rotationTimer;  // Timer pour le changement de rotation
    private float currentRotationTime;  // Temps actuel entre chaque rotation

    private void Start()
    {
        // Initialiser le timer de rotation et le temps entre chaque rotation
        rotationTimer = 0f;
        currentRotationTime = GetRandomRotationTime();

        // Calculer une rotation cible aléatoire pour chaque axe
        float randomXRotation = Random.Range(10f, 60f);
        float randomYRotation = Random.Range(0f, 180f);
        float randomZRotation = Random.Range(-10f, 10f);
        targetRotation = Quaternion.Euler(randomXRotation, randomYRotation, randomZRotation);
    }

    private void Update()
    {
        // Mettre à jour le timer de rotation
        rotationTimer += Time.deltaTime;

        if (rotationTimer >= currentRotationTime)
        {
            // Générer des rotations aléatoires pour chaque axe
            float randomXRotation = Random.Range(10f, 60f);
            float randomYRotation = Random.Range(0f, 180f);
            float randomZRotation = Random.Range(-10f, 10f);

            // Combinaison des rotations aléatoires sur les axes X, Y et Z
            targetRotation = Quaternion.Euler(randomXRotation, randomYRotation, randomZRotation);

            // Réinitialiser le timer de rotation et le temps entre chaque rotation
            rotationTimer = 0f;
            currentRotationTime = GetRandomRotationTime();
        }

        // Faire tourner progressivement le spotlight vers la nouvelle rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private float GetRandomRotationTime()
    {
        return Random.Range(minRotationTime, maxRotationTime);
    }
}