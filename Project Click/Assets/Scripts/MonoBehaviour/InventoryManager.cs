using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Inventory data;

    public GameObject root;
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < root.transform.childCount; i++) {
            slots.Add(root.transform.GetChild(i).gameObject);
        }
    }

    private void Update() {
        for(int i = 0; i < slots.Capacity; i++) {

            Image icon = slots[i].GetComponentInChildren<Image>();

            if(data.GetAtIndex(i) != null) {
                icon.enabled = true;
                icon.sprite = data.GetAtIndex(i).GetItemImage();
            }
            else icon.enabled = false;

        }
    }
}
