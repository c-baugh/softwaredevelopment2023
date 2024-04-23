using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI;
    private bool isInventoryVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Change KeyCode.E to your desired keybind
        {
            isInventoryVisible = !isInventoryVisible;
            inventoryUI.SetActive(isInventoryVisible);
        }
    }
}