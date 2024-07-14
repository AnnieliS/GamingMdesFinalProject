using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform targetPosition;
    public float movementDuration = 3f;
    public float floatingHeight = 0.5f;
    public float floatingSpeed = 1f;
    public float waitTime = 1f; // Temps d'attente r�glable dans l'inspecteur

    private void Start()
    {
        StartCoroutine(MoveCar(targetPosition.position, movementDuration));
    }

    private System.Collections.IEnumerator MoveCar(Vector3 target, float duration)
    {
        Vector3 startPosition = transform.position;
        Vector3 floatingOffset = Vector3.zero;

        float elapsedTime = 0f;
        float randomDelay = Random.Range(0f, 1f); // D�calage al�atoire au d�but du mouvement

        yield return new WaitForSeconds(randomDelay);

        while (elapsedTime < duration)
        {
            // Calculer le d�placement vertical en fonction du temps et de la vitesse de flottement
            float floatingAmount = Mathf.Sin((elapsedTime + randomDelay) * floatingSpeed) * floatingHeight;
            floatingOffset.y = floatingAmount;

            // Appliquer la position flottante et le mouvement horizontal
            transform.position = startPosition + floatingOffset + (target - startPosition) * (elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target; // Atteindre la position cible

        yield return new WaitForSeconds(waitTime); // Attendre le temps sp�cifi� avant de revenir

        transform.position = startPosition; // T�l�porter la voiture � la position initiale

        StartCoroutine(MoveCar(target, duration)); // D�marrer le mouvement vers la position cible
    }
}