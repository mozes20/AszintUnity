using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GroundItem : MonoBehaviour
{
	public Text TextObject;
	/*
	
	private string nullText="";


	private void OnTriggerEnter(Collider other)
	{
		TextObject.text = text;
	}


	private void OnTriggerExit(Collider other)
	{
		TextObject.text = nullText;
	}
	private void OnDestroy()
	{
		TextObject.text = nullText;
	}
	*/

	public ItemObject item;

    private void OnDestroy()
    {
		TextObject.text = "";
    }
}
