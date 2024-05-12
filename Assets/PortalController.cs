using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    
    public Transform destination;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Teleport");
        if (collision.CompareTag("Player"))
        {
            player.transform.position = destination.transform.position;
        }
    }
}
