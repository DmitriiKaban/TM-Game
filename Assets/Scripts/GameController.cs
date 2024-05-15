using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialog, Battle}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController; // access from Unity
    public static GameObject window;
    GameState state;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
            if(window!=null)
                window.SetActive(false);
        } else if (state == GameState.Dialog)
        {
            Debug.Log("GAME STATE IS DIALOG!!!!");
            DialogManager.Instance.HandleUpdate();
            window.SetActive(true);
        } else if (state == GameState.Battle)
        {
            
        }
    }

    public void SetState()
    {
        state = GameState.FreeRoam;
        DialogManager.Instance.HideDialog();
    }
}
