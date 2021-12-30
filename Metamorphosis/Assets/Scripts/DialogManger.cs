using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DialogManger : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int letterPerSecond;
    public event Action OnShowDialog;
    public event Action OnCloseDialog;
    public static DialogManger Instance { get; private set; } //instance of dialogmanger to reference it (private to set it from iside the class)
   
    private void Awake()
    {
        Instance = this;
    }
    Dialog dialog;
    int currentLine = 0;
    bool isTyping;
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();

        OnShowDialog?.Invoke();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }
 




    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z)&& !isTyping)
        {
            ++currentLine;
            if (currentLine<dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;//added it one by one
            yield return new WaitForSeconds(1f/ letterPerSecond);//to wait a second to write
        }
        isTyping = false;
    }
}
