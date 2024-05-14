using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    [SerializeField] private float gemRadius;
    [SerializeField] private Tilemap gemTilemap;
    [SerializeField] private TileBase gemTile;
    [SerializeField] private GameObject inventoryGO;
    private bool isMoving;
    private bool isAttacking = false;
    private Vector2 input;
    private Animator animator;
    private InventoryClass ic;
    public LayerMask solidObjectsLayer; 
    public LayerMask interactableLayer;
    public LayerMask battleLayer;
    public LayerMask solidObjectLayer2;
    public LayerMask gemsLayer;
    private GameObject currentTeleporter;

    public void SetIsMoving(bool b)
    {
        isMoving = b;
    }

    private void Awake()
    {
        ic = GetComponent<InventoryClass>();
        animator = GetComponent<Animator>();
    }

    public void HandleTeleport()
    {
        isMoving = false;
        StopAllCoroutines();
    }
    
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Hey");
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporters>().GetDestination().position;
            }
        }
        
        if (!isMoving)
        {
            Debug.Log("not");
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryGO.SetActive(!inventoryGO.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            // Set isAtacking to true to start the attack animation
            isAttacking = true;
            var pos = new Vector3Int((int)transform.position.x, (int)transform.position.y - 1, 0);
           // Debug.Log(pos);
            gemTile = gemTilemap.GetTile(pos);
            if(gemTile != null) 
                ic.Dig(gemTile.name.Last());
            animator.SetBool("isAtacking", isAttacking);
        }

        // Check if the attack key is released
        if (Input.GetKeyUp(KeyCode.X))
        {
            // Set isAtacking to false to stop the attack animation
            isAttacking = false;
            animator.SetBool("isAtacking", isAttacking);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        isMoving = false;
        StopAllCoroutines();
        if (other.CompareTag("Teleporter"))
        {
            currentTeleporter = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
        {
            if (other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.05f, solidObjectsLayer | solidObjectLayer2) != null)
        {
            return false;
        }
        
        if (Physics2D.OverlapCircle(targetPos, gemRadius, gemsLayer) != null)
        {
            return false;
        }
        
        if (Physics2D.OverlapCircle(targetPos, 0.02f, interactableLayer) != null)
        {
            return false;
        }

        return true;
    }
}