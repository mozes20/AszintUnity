using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probacsere : MonoBehaviour
{
    [SerializeField] private List<GameObject> Cserelheto;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject element in Cserelheto)
        {
            if (element != null)
            {
                element.GetComponentInChildren<DoorMechanik>().closed = true;
                element.GetComponent<prefabeswitch>().nowChange = true;
            }
        }
    }
}
