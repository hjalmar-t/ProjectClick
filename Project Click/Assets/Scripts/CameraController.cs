using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float maxZoom = 15;
    float minZoom = 2;

    public GameObject target;

    private void Start() {

    }

    private void Update() {
        RotateCamera();
        Zoom();
        //Snap();
    }

    private void LateUpdate() {
        Snap();
    }

    void RotateCamera() {

        Vector3 mouseHorizontal = new Vector3 (0, Input.GetAxisRaw("Mouse X"), 0);
        Vector3 mouseVertical = new Vector3 (0, Input.GetAxisRaw("Mouse Y"), 0);

        if (Input.GetButton("Fire3")) {
            transform.Rotate(mouseHorizontal * 5);

            if( (-mouseVertical.y > 0 && Camera.main.transform.localPosition.y < 8) || (-mouseVertical.y < 0 && Camera.main.transform.localPosition.y > 0.5f) ) {
                Camera.main.transform.Translate(-mouseVertical, Space.World);
            }

        }
    }

    void Zoom() {
        Transform camera = Camera.main.transform;
        float scrollAxis = Input.GetAxis("Mouse ScrollWheel") * 50;

        //Debug.Log(scrollAxis);
        //Camera.main.transform.localPosition = Camera.main.transform.localPosition + (Vector3.forward * Input.GetAxisRaw("Mouse ScrollWheel") * 400 * Time.deltaTime);

        //if( (scrollAxis < 0 && camera.localPosition.z > -maxZoom) || (scrollAxis > 0 && camera.localPosition.z < -minZoom) ) {
        //    camera.localPosition = camera.localPosition + (Vector3.forward * scrollAxis * 40 * Time.deltaTime);
        //}

        Camera.main.fieldOfView = Camera.main.fieldOfView - scrollAxis;
        if(Camera.main.fieldOfView > 90) Camera.main.fieldOfView = 90;
        if(Camera.main.fieldOfView < 20) Camera.main.fieldOfView = 20;
    }

    void Snap() {
        Transform camera = Camera.main.transform;

        transform.position = target.transform.position + Vector3.up;

        Camera.main.transform.LookAt(transform);

        //if(camera.localPosition.z < -maxZoom) camera.localPosition = new Vector3(camera.localPosition.x, camera.localPosition.y, -maxZoom);
        //if(camera.localPosition.z > -minZoom) camera.localPosition = new Vector3(camera.localPosition.x, camera.localPosition.y, -minZoom);

        if(camera.localPosition.y > 8) camera.localPosition = new Vector3(camera.localPosition.x, 8, camera.localPosition.z);
        if(camera.localPosition.y < 0.5f) camera.localPosition = new Vector3(camera.localPosition.x, 0.5f, camera.localPosition.z);

    }
}
