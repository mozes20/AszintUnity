using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabeswitch : MonoBehaviour
{
    [SerializeField]public GameObject prefab1;
    public GameObject prefab2;
    public bool nowChange= false;


    // Start is called before the first frame update
    void Start()
    {
        if (prefab2==null) {
            prefab2 = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nowChange)
        {
            Instantiate(prefab1.gameObject, prefab2.transform.position, prefab2.gameObject.transform.rotation);
            Destroy(this.gameObject);
            nowChange = false;
        }

    }

}

