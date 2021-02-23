using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
	public InventoryObject inventory;
	public string Elem;
	public MouseLook LampaBattery;
	private InventorySlot tmp;
	private bool isInventoryOpen = false;

	[SerializeField] private GameObject inv;

	[Header("RaycastSelect")]
	[SerializeField] private string selectableTag = "Selectable";
	[SerializeField] private string DoorKeyUse = "Door";

	[SerializeField] private Text EditAbleText;
	private Transform _selection;


	// Start is called before the first frame update

	private void Start()
	{
		inventory.load();
		inv.SetActive(false);

	}



	private void Update()
	{





		if (Input.GetKeyDown(KeyCode.Return)) {
			inventory.save();

		}
		if (Input.GetKeyDown(KeyCode.Tab)) {
			if (!isInventoryOpen)
			{
				inv.SetActive(true);
				isInventoryOpen = true;
			}
			else {

				inv.SetActive(false);
				isInventoryOpen = false;
			}

		}

		if (Input.GetKeyDown(KeyCode.R))
		{

			for (int i = 0; i < inventory.container.items.Count; i++)
			{
				Debug.LogError(inventory.container.items.Count);
				if (inventory.container.items[i].item.name == "Elem") {
					tmp = inventory.container.items[i];
					if (tmp.amount >= 1) {
						LampaBattery.battery = 100;
						LampaBattery.butteryscript.SetButtery(100);

					}
					//inventory.getItem(tmp.item, 1);

				}
			}
		}

		if (_selection != null)
		{
			var selectionRenderer = _selection.GetComponent<Renderer>();
			EditAbleText.text = "";
			_selection = null;
		}

		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 4f))
		{
			Debug.DrawLine(ray.origin, hit.point);
			var selection = hit.transform;
			if (selection.CompareTag(selectableTag))
			{

				var adat = selection;
				EditAbleText.text = adat.gameObject.GetComponent<GroundItem>().item.description;
				_selection = selection;
				if (Input.GetMouseButtonDown(1))
				{
					var item = adat.gameObject.GetComponent<GroundItem>();
					Debug.Log(item.item.name);
					if (item)
					{
						inventory.addItem(new Item(item.item), 1);
						Destroy(adat.gameObject);
					}
				}
			}

			if (selection.CompareTag(DoorKeyUse)) {
				if (Input.GetMouseButtonDown(1))
				{
					if (selection.GetComponent<DoorMechanik>().closed) {
					if (inventory.getElement(selection.GetComponent<DoorMechanik>().keyNumber)) {
						selection.GetComponent<DoorMechanik>().closed = false;
                    }
                    else
                    {
						EditAbleText.text = "Nincs nálad a kulcs"; 

					}
                    }
				}
			}



		}
	}


		private void OnApplicationQuit()
		{
			inventory.container.items.Clear();
		}
	} 


