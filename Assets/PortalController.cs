using System;
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
        Debug.Log(player.name);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Teleportc");
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Teleport2c");
            player.transform.position = destination.transform.position;
            player.GetComponent<PlayerController>().HandleTeleport();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        
        Debug.Log("Teleports");
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Teleport2s");
            // player.transform.position = destination.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Teleport");
        Debug.Log(collision.transform.tag);
        Debug.Log(collision.transform.name);
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Teleport2");
           // player.transform.position = destination.transform.position;
        }  
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Teleport3");
           // player.transform.position = destination.transform.position;
        }
    }
}
