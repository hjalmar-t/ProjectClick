using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveGame save;
    public GameObject player;

    private void Start() {
        if(player != null) {
            player.transform.position = save.playerPosition;
            save.currentInventory.Copy(save.savedInventory);
        }
    }
}
