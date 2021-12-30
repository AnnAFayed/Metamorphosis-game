using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    
    [SerializeField] Dialog dialog;
    Healer healer;
    private Transform initator;
    private void Awake()
    {
        healer = GetComponent<Healer>();
    }
    public void Interact()
    {
        StartCoroutine(DialogManger.Instance.ShowDialog(dialog));//to pass dialog
   
        if (healer != null)
        {
           healer.Heal(initator, dialog);
        }
    }
}
