using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    [SerializeField] private SlotClass[] startingItems;

    private SlotClass[] items;

    private GameObject[] slots;

    private SlotClass movingSlot;

    private SlotClass tempSlot;

    private SlotClass originalSlot;

    bool isMovingItem;
    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];

        //sets all of the slots for IMS system.

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }
        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }

        //set all the slots 
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();

        Add(itemToAdd, 1);
        Remove(itemToRemove);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  //we clicked! 
        {
            //find the closest slot (the slot we clicked on)
            if (isMovingItem)
            {
                //end item move
                EndItemMove();
            }
            else
                BeginItemMove();

        }

    }
    #region Inventory Utils
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].GetQuantity() + "";
                else
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }

            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";


            }
        }
    }

    public bool Add(ItemClass item, int quantity)
    {
        // items.Add(item);
        //check if inventory contains item


        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
            slot.AddQuantity(1);
        else
        {

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null) //this is an empty slot 
                {
                    items[i].AddItem(item, quantity);
                    break;


                }


            }

        }

        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {

        // items.Remove(item);
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
                temp.SubQuantity(1);
            else
            {
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }

                items[slotToRemoveIndex].Clear();
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;

    }

    public SlotClass Contains(ItemClass item)
    {
        for (int i = 0; i < items.Length; i++)
        {

            if (items[i].GetItem() == item)
                return items[i];
        }

        return null;
    }
    #endregion Inventory Utils 

    #region Moving Stuff
    private bool BeginItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.GetItem() == null)
            return false; //there is no item to move!

        movingSlot = new SlotClass(originalSlot);
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null)
        {
            Add(movingSlot.GetItem(), movingSlot.GetQuantity());
            movingSlot.Clear();
        }
        else
        {
            if (originalSlot.GetItem() != null)
            {
                if (originalSlot.GetItem() == movingSlot.GetItem()) //they're the same item (they should stack)
                {
                    if (originalSlot.GetItem().isStackable)
                    {
                        originalSlot.AddQuantity(movingSlot.GetQuantity());
                        movingSlot.Clear();
                    }
                    else
                        return false;

                }
                else
                {
                    tempSlot = new SlotClass(originalSlot); //a = b
                    originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity()); //b = c 
                    movingSlot.AddItem(tempSlot.GetItem(), tempSlot.GetQuantity()); //a = c
                    RefreshUI();
                    return true;
                }
            }
            else //place item as usual.
            {
                originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                movingSlot.Clear();

            }
        }

        isMovingItem = false;
        RefreshUI();
        return true;
    }
    private SlotClass GetClosestSlot()
    {


        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 32)
                return items[i];
        }

        return null;

    }


    #endregion
}




