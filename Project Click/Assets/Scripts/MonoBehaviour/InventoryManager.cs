using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    //Add an inventory slot class that has a reference to all things that need to be GetComponented
    //Initialize it when compiling the array of slot objects

    public enum InventoryState{
        none,
        use,
        move
    }

    InventoryState state;

    public Inventory data;

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

        state = InventoryState.none;

        for(int i = 0; i < Inventory.size; i++) {
            slots[i] = Instantiate(slotPrefab, root.transform);
            int x = i;
            slots[i].GetComponentInChildren<Button>().onClick.AddListener(delegate { ButtonFunction(x); } );
        }
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject()) {
            data.SetCurrent(-1);
            state = InventoryState.none;
            ItemSelected(false);
        }
    }

    private void LateUpdate() {

        for(int i = 0; i < slots.Length; i++) {

            Image icon = slots[i].GetComponentInChildren<Image>();
            if(data.GetAtIndex(i) != null) {
                //slots[i].GetComponentInChildren<Button>().interactable = true;
                icon.enabled = true;
                icon.sprite = data.GetAtIndex(i).GetItemImage();
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
            state = InventoryState.none;
            break;
        case 1:
            state = InventoryState.use;
            break;
        case 2:
            state = InventoryState.move;
            break;
        }
    }

    public void ButtonFunction(int i) {
        if(state == InventoryState.move) {
            data.Swap(i);
            state = InventoryState.none;
        }

        Item item = data.GetAtIndex(i);
        if(item == null) return;

        Debug.Log("Button index " + i + " pressed.");
        data.SetCurrent(i);
        ItemSelected(true);

        selectedIcon.sprite = item.GetItemImage();
        selectedDesc.text = string.Format("{0}: {1}", item.GetItemName(), item.GetDescription());
    }

    public void ItemSelected(bool b) {
        useButton.interactable = b;
        moveButton.interactable = b;

        selectedIcon.enabled = b;
        selectedDesc.enabled = b;

    }
}
