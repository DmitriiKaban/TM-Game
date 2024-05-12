using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private bool isMoving;
    private bool isAtacking = false;
    private Vector2 input;
    private Animator animator;
    public LayerMask solidObjectsLayer; 
    public LayerMask interactableLayer;
    public LayerMask battleLayer;
    public LayerMask solidObjectLayer2;
    public LayerMask teleportLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");   

            // no diagonal movement disabled
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                
                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            // Set isAtacking to true to start the attack animation
            isAtacking = true;
            animator.SetBool("isAtacking", isAtacking);
        }

        // Check if the attack key is released
        if (Input.GetKeyUp(KeyCode.X))
        {
            // Set isAtacking to false to stop the attack animation
            isAtacking = false;
            animator.SetBool("isAtacking", isAtacking);
        }
    }

    void Interact()
    {
        Debug.Log("PLAYER INTERACT METHOD");
        Vector3 facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Vector3 interactPos = transform.position + facingDir;

        // Debug.DrawLine(transform.position, interactPos, Color.red, 2f);
        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        if (collider != null)
        {
            Debug.Log("SHOULD INTERACT HERE!!!!");
            collider.GetComponent<Interactable>()?.Interact();
        }
        
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();
        CheckForTeleport();
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.01f, battleLayer) != null)
        {
            if (Random.Range(1, 100) <= 50)
            {
                Debug.Log("A battle has started!");
            }
        }
    }

    private void CheckForTeleport()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.001f, teleportLayer) != null)
        {
            Debug.Log("A teleporter!");
        }
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.05f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        
        if (Physics2D.OverlapCircle(targetPos, 0.05f, solidObjectLayer2) != null)
        {
            return false;
        }

        return true;
    }
}