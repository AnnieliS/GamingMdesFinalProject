using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] float movementRadius = 2f;
    [SerializeField] float maxWait = 10f;
    NavMeshAgent agent;
    Vector3 rootPosition;
    Animator animator;
    float moveX;
    float moveY;
    float moveZ;
    bool canMove = true;
    bool isIdle = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveY = transform.position.y;
        rootPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Animator[] children = GetComponentsInChildren<Animator>();
        foreach (Animator child in children)
        {
            if (child.tag == "npcSprite")
            {
                animator = child;
            }
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (agent.remainingDistance < 0.1f)
        {
            canMove = true;
        }
        if (canMove)
        {
            StartCoroutine(SelectNewDestination());
        }
    }

    IEnumerator SelectNewDestination()
    {
        if (!isIdle)
        {
            isIdle = true;
            animator.SetTrigger("idle");
        }
        canMove = false;
        float waitTime = Random.Range(2f, maxWait);
        yield return new WaitForSeconds(waitTime);
        isIdle = false;
        moveX = Random.Range(0.5f, movementRadius);
        moveZ = Random.Range(0.5f, movementRadius);
        Vector3 newPosition = new Vector3(rootPosition.x + moveX, moveY, rootPosition.z + moveZ);
        agent.SetDestination(newPosition);
        animator.SetTrigger("walk");
    }
}
