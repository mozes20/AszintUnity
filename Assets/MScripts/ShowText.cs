using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{

    public Text TextObject;
    private string NullText = "";

    private void Start()
    {
        
    }

    public void SetText(string setText)
    {
        TextObject.text = setText;
        Debug.Log("Be lett állitva");
    }

    public void UnSetText()
    {
        TextObject.text = NullText;

    }


}
