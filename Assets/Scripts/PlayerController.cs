using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject pointOfView;
    public float moveSpeed = 10;
    public float cameraSpeed = 1000;
    private float currentRotationY = 0f;

    // Update is called once per frame
    void Update()
    { 
        float forwardInput = Input.GetAxis("Forward / Backward");
        float sideInput = Input.GetAxis("Left / Right");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSpeed;
        currentRotationY -= mouseY;
        currentRotationY = Mathf.Clamp(currentRotationY, -90f, 90f);
        transform.Translate(new Vector3(sideInput, 0, forwardInput) * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, mouseX, 0) * cameraSpeed * Time.deltaTime);
        pointOfView.transform.eulerAngles = new Vector3(currentRotationY, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
