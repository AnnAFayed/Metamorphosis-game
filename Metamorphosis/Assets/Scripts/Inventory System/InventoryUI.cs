using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{


    [SerializeField] GameObject itemList;
    [SerializeField] ItemSlotUI iteamSloutUI;

    private void Awake()
    {
       
       
         inventory = Inventory.getInventory();
    }
    Inventory inventory;
    private void Start()
    {
        UpdateItemList();
    }

    void UpdateItemList()
    {
        foreach (Transform child in itemList.transform)
            Destroy(child.gameObject);

        foreach (var itemSlot in inventory.Slots)
        {
           var slotUIObj = Instantiate(iteamSloutUI, itemList.transform);
            slotUIObj.SetData(itemSlot);
        }

    }

    public void HandleUpdate(System.Action onBack)
    {


        if (Input.GetKeyDown(KeyCode.X))
            onBack?.Invoke();
    }

}
