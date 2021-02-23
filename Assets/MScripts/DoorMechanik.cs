using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanik : MonoBehaviour
{
    [SerializeField] public bool closed = false;
    [SerializeField] public int keyNumber = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (!closed)
        {
            JointLimits limits = this.GetComponent<HingeJoint>().limits;
            limits.max = 90;
            this.GetComponent<HingeJoint>().limits = limits;
        }
        else
        {
            JointLimits limits = this.GetComponent<HingeJoint>().limits;
            limits.max = 1;
            this.GetComponent<HingeJoint>().limits = limits;
        }

    }
}
