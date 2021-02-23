using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closed : MonoBehaviour
{
    [SerializeField] private GameObject rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid.GetComponent<Rigidbody>().isKinematic = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            rigid.GetComponent<Rigidbody>().isKinematic = false;

            Quaternion originalPos = rigid.transform.rotation;
   

 
                rigid.transform.rotation = new Quaternion(originalPos.x,  - 0.2f, originalPos.z, originalPos.w);
          
            
        }
        

        
    }
}
