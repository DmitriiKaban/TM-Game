using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;
    public event Action OnShowDialog;
    public event Action OnHideDialog;
    
    Dialog dialog;
    int currentLine = 0;
    bool isTyping = false;
    public static DialogManager Instance { get; private set; } // making it public to other classes

    private void Awake()
    {
        Debug.Log("AWAKE DIALOG MANAGER!");
        Instance = this;
    }

    public void HandleUpdate()
    {
        Debug.Log("HANDLE UPDATE DIALOG MANAGER!");
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
            }
        }
    }

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string line) // printing char by char
    {
        isTyping = true;
        dialogText.text = "";

        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        isTyping = false;
    }

    public IEnumerator HideDialog()
    {
        dialogBox.SetActive(false);
        Debug.Log("asd");
        yield return null;
    }
}
