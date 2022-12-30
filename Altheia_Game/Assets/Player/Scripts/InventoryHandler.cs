using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

public class InventoryHandler : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("1stPersonCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !inventory.gameObject.activeSelf)
        {
            playerCamera.GetComponent<Camera_Controller>().moveBlocked = true;
            inventory.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.I) && inventory.gameObject.activeSelf)
        {
            playerCamera.GetComponent<Camera_Controller>().moveBlocked = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            inventory.SetActive(false);
        }

    }
    public void Exit() {
        Debug.Log("exit");
        playerCamera.GetComponent<Camera_Controller>().moveBlocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inventory.SetActive(false);
    }
}
