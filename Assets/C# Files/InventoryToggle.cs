using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject hotbarUI;

    private bool isInventoryVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isInventoryVisible = !isInventoryVisible;
            inventoryUI.SetActive(isInventoryVisible);
        }
    }
}
