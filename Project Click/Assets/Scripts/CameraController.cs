using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float MaxDistance;
    public float minDistance;

    public GameObject target;

    private void Start() {

    }

    private void Update() {
        transform.position = target.transform.position + Vector3.up;
        RotateCamera();
        Zoom();
        Camera.main.transform.LookAt(transform);
    }

    void RotateCamera() {
        Vector3 mouseHorizontal = new Vector3 (0, Input.GetAxisRaw("Mouse X"), 0);
        Vector3 mouseVertical = new Vector3 (0, Input.GetAxisRaw("Mouse Y"), 0);

        if (Input.GetKey(KeyCode.Mouse2)) {
            transform.Rotate(mouseHorizontal * 5);
            Camera.main.transform.Translate(mouseVertical);
        }
    }

    void Zoom() {
        Camera.main.transform.localPosition = Camera.main.transform.localPosition + (Vector3.forward * Input.GetAxisRaw("Mouse ScrollWheel") * 250 * Time.deltaTime);
    }
}
