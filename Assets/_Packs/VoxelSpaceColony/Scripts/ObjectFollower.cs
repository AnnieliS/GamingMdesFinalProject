using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    /// <summary>
    /// This script is for the camera follow vehicle or to create trailer with car
    /// </summary>

    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void  FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation() 
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position,targetPosition,translateSpeed*Time.deltaTime);
    }

    private void HandleRotation() 
    {

        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation,rotation,rotationSpeed * Time.deltaTime);
    }
}
