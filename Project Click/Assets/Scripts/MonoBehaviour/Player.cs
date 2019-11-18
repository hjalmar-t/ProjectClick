using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject clickTarget;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.P) && clickTarget != null) Debug.Log("Currentmost clicked object: " + clickTarget.name);

        Ray mousePointNormal = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseClick;

        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            if(Physics.Raycast(mousePointNormal, out mouseClick, Mathf.Infinity)) {
                agent.destination = mouseClick.point;
                clickTarget = mouseClick.collider.gameObject;
            }
        }
    }
}
