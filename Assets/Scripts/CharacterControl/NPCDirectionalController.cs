using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDirectionalController : MonoBehaviour
{
    [SerializeField] float backAngle = 65f;
    [SerializeField] float sideAngle = 155f;
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        animator.SetTrigger("idle");
    }

    private void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        // Debug.Log(camForwardVector);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0f, -1f);

        float angle = Mathf.Abs(signedAngle);

        if( signedAngle < 0){
            spriteRenderer.flipX = true;
        }

        else{
            spriteRenderer.flipX = false;
        }

        if (angle < backAngle)
            //back animation
            animationDirection = new Vector2(0f, -1f);

        else if (angle < sideAngle)
            //side animation
            animationDirection = new Vector2(1f, 0f);

        else
            //front animation
            animationDirection = new Vector2(0f, 1f);

        // animator.SetFloat("moveX", animationDirection.x);
        // animator.SetFloat("moveY", animationDirection.y);
}
}