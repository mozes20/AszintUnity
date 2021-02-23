using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchScript : MonoBehaviour
{
    CapsuleCollider playerCol;
    CharacterController controller;
    public float crouchSpeed=2f;
    public cameraBobScript cmb;

    public float reducedHeight;
    public PlayerMovementScript pys;
    float base_speed;
    float originalHeight;


    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        controller = GetComponent<CharacterController>();


        originalHeight = playerCol.height;

        base_speed = pys.speed;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
            pys.speed = crouchSpeed;
            cmb.bobFrequency = crouchSpeed;
          
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            goUp();
            pys.speed = base_speed;
            cmb.bobFrequency = base_speed;
        }
        
    }

    void Crouch()
    {
        playerCol.height = reducedHeight;
        controller.height = reducedHeight;

    }

    void goUp() {

        playerCol.height = originalHeight;
        controller.height = originalHeight;

    }


}
