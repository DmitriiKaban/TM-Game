using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    [SerializeField] string id;
    [SerializeField] private GameObject window;
    
    public void Interact()
    {
        Debug.Log("Interact with NPC!!!!!");
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        //window.SetActive(true);
        GameController.window = window;
        switch (id)
        {
            case "abby":
            {
                
                break;
            }
            case "jack":
            {
                
                break;
            }
            case "lilly":
            {
                
                break;
            }
            case "martha":
            {
                
                break;
            }
            case "mason":
            {
                
                break;
            }
            case "millie":
            {
                
                break;
            }
        }
    }
}
