using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    public PlayerTarget target;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update() {
        // Debug command for displaying the currentmost click target
        if(Input.GetKeyDown(KeyCode.P) && target.movementTarget != null) Debug.Log("Currentmost leftclicked object: " + target.movementTarget.name);

        // Get a ray based on the mouse position
        Ray mousePointNormal = Camera.main.ScreenPointToRay(Input.mousePosition);

        ClickToReact(mousePointNormal);
        ClickToInspect(mousePointNormal);

        anim.SetBool("moving", isMoving());

        //if(target.movementTarget == null) return;

        //if(Vector3.Distance(target.movementTarget.transform.position, transform.position) < 1.0f && target.movementTarget.CompareTag("Entity")) {
        //    target.movementTarget.GetComponent<Entity>().Interract();
        //}
    }

    bool isMoving() {
        if(agent.remainingDistance <= agent.stoppingDistance) {
            return false;
        }
        else return true;
    }

    void ClickToReact(Ray mousePointNormal) {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            RaycastHit mouseClick;

            if(Physics.Raycast(mousePointNormal, out mouseClick, Mathf.Infinity)) {
                agent.destination = mouseClick.point;
                target.movementTarget = mouseClick.collider.gameObject;

                if(Vector3.Distance(target.movementTarget.transform.position, transform.position) < 2.0f && target.movementTarget.CompareTag("Entity")) {
                    target.movementTarget.GetComponent<Entity>().Interract();
                    anim.SetTrigger("activate");
                }
            }
        }
    }

    void ClickToInspect(Ray mousePointNormal) {
        if(!EventSystem.current.IsPointerOverGameObject()) {
            RaycastHit mouseClick;

            if(Physics.Raycast(mousePointNormal, out mouseClick, Mathf.Infinity)) {
                target.inspectTarget = mouseClick.collider.gameObject;
            }
        }

        if(Input.GetMouseButtonDown(1)) {
            // function here
        }
    }
}
