using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public Rigidbody2D rb;
    public float collisionOffset = 0f;
    public ContactFilter2D movementFilter;

    Vector2 movement;
    SpriteRenderer spriteRenderer;
    Vector2 movementInput;
    Animator animator;

    private DialogueManager dialoguePanel;
    private Task_UI_Empty taskPanel;
    private Task_UI taskPanel2;
    private Task_UI_Collection_Question taskPanel3;
    private Inventory_UI inventoryPanel;
    private Question_UI questionPanel;
    private Quite_UI quitePanel;

    bool canMove = true;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (!MoveCheck())
        {
            animator.SetBool("isMoving", false);
            return;
        }
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                int count = rb.Cast(
                    movementInput,
                    movementFilter,
                    castCollisions,
                    moveSpeed * Time.fixedDeltaTime + collisionOffset
                );
                if (count == 0)
                {
                    rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                    animator.SetBool("isMoving", true);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                }
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

    public bool MoveCheck()
    {
        dialoguePanel = GameObject.FindObjectOfType<DialogueManager>();
        inventoryPanel = GameObject.FindObjectOfType<Inventory_UI>();
        quitePanel = GameObject.FindObjectOfType<Quite_UI>();
        // bool quiteUIStatus = quitePanel.quiteUIActive;
        bool taskUIStatus;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            taskPanel2 = GameObject.FindObjectOfType<Task_UI>();
            taskUIStatus = taskPanel2.taskUIActive;
        }
        else if (
            SceneManager.GetActiveScene().buildIndex == 4
            || SceneManager.GetActiveScene().buildIndex == 5
            || SceneManager.GetActiveScene().buildIndex == 6
        )
        {
            taskPanel3 = GameObject.FindObjectOfType<Task_UI_Collection_Question>();
            taskUIStatus = taskPanel3.taskUIActive;
        }
        else
        {
            taskPanel = GameObject.FindObjectOfType<Task_UI_Empty>();
            taskUIStatus = taskPanel.taskUIActive;
        }
        if(SceneManager.GetActiveScene().buildIndex == 4
            || SceneManager.GetActiveScene().buildIndex == 6){
            questionPanel = GameObject.FindObjectOfType<Question_UI>();
            if (!dialoguePanel.dialogueUIActive && !taskUIStatus && !inventoryPanel.inventoryUIActive && !questionPanel.questionUIActive && !quitePanel.quiteUIActive)
            {
                return true;
            }
            else
                return false;
        }
        else{
            if (!dialoguePanel.dialogueUIActive && !taskUIStatus && !inventoryPanel.inventoryUIActive && !quitePanel.quiteUIActive)
            {
                return true;
            }
            else
                return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
        print("Fire pressed");
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
