using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    //CAMERA MOTION
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public Transform playerTF;
    public bool moveBlocked = false;

    //CAMERA SWAY
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (!moveBlocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            Debug.Log("x: " + mouseX + "y: " + mouseY);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerTF.Rotate(Vector3.up * mouseX);
        }         
    }    
}
