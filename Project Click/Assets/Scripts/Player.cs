using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        Ray mousePointNormal = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseClickPosition;

        if(Input.GetMouseButtonDown(0)) {
            if(Physics.Raycast(mousePointNormal, out mouseClickPosition, Mathf.Infinity)) {
                agent.destination = mouseClickPosition.point;
            }
        }
    }
}
