using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all game objects that can be interracted with.
/// </summary>
/// <remarks>
///  Doors, buttons etc...
/// Collectable items, save points...
/// </remarks>
public class Entity : MonoBehaviour
{
    protected bool activated = false;
    public SaveGame save;

    public string entityName = "Name";
    public string entityDescription = "Description";
    public string interactionName = "Interract";

    public string getEntityName() { return entityName; }
    public string getDescription() { return entityDescription; }
    public string getInteractionName() { return interactionName; }

    public virtual void Interract() {
        Debug.LogWarning("Error: " + this.name + " called the default ENTITY interraction method instead of the child specific one.");
    }

    public void Examine() {
        Debug.LogWarning(this.name + "has been examined");
    }

    protected void OnMouseDown() {
        Debug.Log(this.name + " has been clicked.");
        if(Vector3.Distance(transform.position, save.player.transform.position) <= 2.0f) {
            Interract();
        }
    }

    protected void OnMouseEnter() {
        save.SetHoverTarget(this);
    }

    protected void OnMouseExit() {
        save.SetHoverTarget(null);
    }

    protected void OnDisable() {
        save.SetHoverTarget(null);
    }

}

