using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float runSpeed = 3f;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Rigidbody rb;

    UnityEngine.Vector3 movement;
    UnityEngine.Vector2 moveValue;
    float moveSpeed;

    private static PlayerMovement instance;

    bool canMove = true;
    bool switched = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Movement Manager in the scene.");
            Destroy(this.gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        moveSpeed = walkSpeed;
    }

    public static PlayerMovement GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        // gameObject.transform.position += movement;
        // rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        if (canMove)
        {
            CameraRelationMovement();
            if (!switched)
            {
                Invoke("ToggleAnims", UnityEngine.Random.Range(1, 5));
                switched = true;
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<UnityEngine.Vector2>() * moveSpeed;

        // Debug.Log(moveValue.x.ToString() + ',' + moveValue.y.ToString());
        //gameObject.transform.rotation = new Quaternion(value.x*90 + gameObject.transform.rotation.x, 0f, value.y*90 + gameObject.transform.rotation.z, 0f);
        // Debug.Log(moveValue);
        // Debug.Log(Mathf.Abs(moveValue.x));

        if ((Mathf.Abs(moveValue.x) > walkSpeed) || (Mathf.Abs(moveValue.y) > walkSpeed))
        {
            // Debug.Log("run");
            animator.SetTrigger("run");
        }

        else if (moveValue.x != 0 || moveValue.y != 0)
        {
            // animator.SetBool("isRunning", true);
            // Debug.Log("walk");

            animator.SetTrigger("walk");
        }

        else
        {
            animator.SetTrigger("idle");
        }


        movement = new UnityEngine.Vector3(moveValue.x * moveSpeed * Camera.main.transform.forward.x, 0f, moveValue.y * moveSpeed * Camera.main.transform.right.x) * Time.deltaTime;

        if (moveValue.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        else
        {
            spriteRenderer.flipX = false;
        }

        // animator.SetFloat("moveX", moveValue.x);
        // animator.SetFloat("moveY", -moveValue.y);


        // gameObject.transform.position += movement;

    }

    public void RunToggle(InputAction.CallbackContext context)
    {
        if (moveSpeed == walkSpeed)
            moveSpeed = runSpeed;
        else
            moveSpeed = walkSpeed;
    }

    void CameraRelationMovement()
    {
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 forwardRelative = camForward * moveValue.y;
        Vector3 rightRelative = camRight * moveValue.x;

        Vector3 moveDir = forwardRelative + rightRelative;

        // Vector3 moveDir = new Vector3(relativeMove.x + movement.x, 0f, relativeMove.y + movement.z);

        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

    }

    private void ToggleAnims()
    {
        switched = false;
        animator.SetTrigger("switchIdle");
        animator.SetTrigger("switchTalk");
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void ResumeMovement()
    {
        canMove = true;
    }

    public void PlayerDie()
    {
        animator.SetTrigger("death");
    }


}
