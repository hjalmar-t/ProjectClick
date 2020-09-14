using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveGame : ScriptableObject
{
    // Reference to the player object that the Game Manager spawns
    public GameObject player;
    // Inventories for the current session and saved session
    public Inventory currentInventory;
    public Inventory savedInventory;
    // Saved position and scene
    public string levelName;
    public Vector3 playerPosition;
    // aa
    public Entity hoverTarget;
    public GameObject clickTarget;

    public void SetPlayer(GameObject p) { player = p; }
    public GameObject GetPlayer() { return player; }

    public bool IsHoveredOver() {
        if(hoverTarget == null) return false;
        return true;
    }
    public void SetHoverTarget(Entity e) { hoverTarget = e; }
    public Entity GetHoverTarget() { return hoverTarget; }

    public void SetClickTarget(GameObject p) { clickTarget = p; }

}
