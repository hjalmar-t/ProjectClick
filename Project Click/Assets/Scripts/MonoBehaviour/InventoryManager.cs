using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    //Add an inventory slot class that has a reference to all things that need to be GetComponented
    //Initialize it when compiling the array of slot objects

    //public enum InventoryState{
    //    none,
    //    use,
    //    move
    //}

    //InventoryState state;

    public Inventory inventory;

    public GameObject root;
    public GameObject slotPrefab;
    GameObject[] slots = new GameObject[Inventory.size];

    public Button useButton;
    public Button moveButton;

    public Image selectedIcon;
    public Text selectedDesc;

    void Start()
    {
        //for(int i = 0; i < root.transform.childCount; i++) {
        //    slots.Add(root.transform.GetChild(i).gameObject);
        //}

        inventory.state = Inventory.State.none;

        for(int i = 0; i < Inventory.size; i++) {
            slots[i] = Instantiate(slotPrefab, root.transform);
            int x = i;
            slots[i].GetComponentInChildren<Button>().onClick.AddListener(delegate { ButtonFunction(x); } );
        }
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject()) {
            inventory.SetCurrent(-1);
            inventory.state = Inventory.State.none;
            ItemSelected(false);
        }
    }

    private void LateUpdate() {

        for(int i = 0; i < slots.Length; i++) {

            Image icon = slots[i].GetComponentInChildren<Image>();
            if(inventory.GetAtIndex(i) != null) {
                //slots[i].GetComponentInChildren<Button>().interactable = true;
                icon.enabled = true;
                icon.sprite = inventory.GetAtIndex(i).GetItemImage();
            }
            else {
                //slots[i].GetComponentInChildren<Button>().interactable = false;
                icon.enabled = false;
            }

        }
    }

    public void SetState(int i) {
        switch(i) {
        case 0:
            inventory.state = Inventory.State.none;
            break;
        case 1:
            inventory.state = Inventory.State.use;
            break;
        case 2:
            inventory.state = Inventory.State.move;
            break;
        }
    }

    public void ButtonFunction(int i) {
        // Do additional tasks before proceeding, based on the state.
        switch(inventory.state) {
        case Inventory.State.use:
            Combine(i);
            break;
        case Inventory.State.move:
            inventory.Swap(i);
            break;
        default:
            break;
        }
        // Reset to base state.
        inventory.state = Inventory.State.none;

        // If the item at current index isn't null, set it as the current item.
        Item item = inventory.GetAtIndex(i);
        if(item == null) return;
        Debug.Log("Button index " + i + " pressed.");
        inventory.SetCurrent(i);

        // Enable graphics based on current item.
        ItemSelected(true);
        selectedIcon.sprite = item.GetItemImage();
        selectedDesc.text = string.Format("{0}: {1}", item.GetItemName(), item.GetDescription());
    }

    void Combine(int i) {
        // Get both members.
        Item itemA = inventory.GetAtIndex(i);
        Item itemB = inventory.GetAtIndex(inventory.current);
        // Return if even one of them is not defined.
        if(itemA == null || itemB == null) return;
        // Combine, if members are compatible. Based on their attributes, delete member(s) if necessary.
        if(itemA.combineWith == itemB || itemB.combineWith == itemA) {
            Item result = itemA.combineTo;
            if(itemA.destroyOnCombine) inventory.RemoveAtIndex(i);
            if(itemB.destroyOnCombine) inventory.RemoveAtIndex(inventory.current);

            inventory.items[i] = result;
        }
    }

    void ItemSelected(bool b) {
        useButton.interactable = b;
        moveButton.interactable = b;

        selectedIcon.enabled = b;
        selectedDesc.enabled = b;

    }
}
