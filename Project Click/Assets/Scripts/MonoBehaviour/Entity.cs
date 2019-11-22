using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all game objects that can be interracted with.
// Doors, buttons etc...
// Collectable items, save points...
public class Entity : MonoBehaviour
{
    protected bool activated = false;

    public string entityName = "Name";
    public string entityDescription = "Description";
    public string interactionName = "Interract";

    public string getEntityName() { return entityName; }
    public string getDescription() { return entityDescription; }
    public string getInteractionName() { return interactionName; }


    public virtual void Interract() {
        Debug.LogWarning("Error: " + this.name + " called the default interraction method instead of the child specific one.");
    }
}
