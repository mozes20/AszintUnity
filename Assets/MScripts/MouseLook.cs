using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Flashlight_PRO flashlight;
    public float battery;
    public float drain;
    public Butteryscript butteryscript;

    public GameObject Inventory;
    [SerializeField] KeyCode OpenInventorykey;
    bool isOpen = false;

    float xRotation = 0f;
    bool isOn;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        butteryscript.SetMaxButtery(100);
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (!(battery <= 0))
        {
            if (!isOpen)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    flashlight.Switch();
                    if (!isOn)
                    {
                        isOn = true;
                    }
                    else
                    {
                        isOn = false;
                    }
                }
            }

            if (isOn)
            {
                battery -= drain;
                butteryscript.SetButtery(battery);
                if (battery <= 50 && battery >= 30)
                {
                    flashlight.spotlight.intensity -=drain/10;
                }
                if (battery > 50 && flashlight.spotlight.intensity <= 3) {
                    flashlight.spotlight.intensity += 0.01f;
                }
                if (battery <= 30) {
                    flashlight.spotlight.intensity = 2f * Mathf.Sin(40 * Time.deltaTime) * Mathf.Cos(60 * Time.deltaTime);
                }
                if (battery <= 0.0)
                {
                    flashlight.Switch();
                    isOn = false;
                }
            }

        }
        if (Input.GetKeyDown(OpenInventorykey))
        {
            if (!isOpen)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }

        }


        if (!isOpen)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);


        }




    }


    void OpenInventory()
    {
        isOpen = true;
        Inventory.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void CloseInventory()
    {
        isOpen = false;
        Inventory.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
