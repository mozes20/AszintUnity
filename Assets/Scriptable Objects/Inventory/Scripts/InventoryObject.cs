using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
	public string savePath;
	public ItemDatabaseObject database;
	public Inventory container;


	public void addItem(Item _item, int _amount)
	{
		/*if(_item.buffs.Length > 0)
		{
			container.items.Add(new InventorySlot(_item.id, _item, _amount));
			return;
		}*/

		//bool hasItem = false;
		for (int i = 0; i < container.items.Count; i++)
		{
			if(container.items[i].item.id == _item.id)
			{
				container.items[i].addAmount(_amount);
				//hasItem = true;
				return;
			}
		}
		//if (!hasItem)


		container.items.Add(new InventorySlot(_item.id, _item, _amount));
	}

	public bool getElement(int id) {
		var result = container.items.Find(x => { return x.item.id == id; });
		var index = container.items.FindIndex(x => { return x.item.id == id; });
		if (result != null)
		{
			if (!(result.amount >= 1))
			{
				return false;
			}
			else
			{
				container.items[index].amount -= 1;
				return true;
			}
		}
		else {
			return false;
		}
	}


	//filekezelés
	[ContextMenu("Save")]
	public void save() 
	{
		/*string saveData = JsonUtility.ToJson(this, true);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath)); // concat = " " + " "
		bf.Serialize(file, saveData);
		file.Close();*/

		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
		formatter.Serialize(stream, container);
		stream.Close();
	}
	public void load()
	{
		if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
		{
			/*BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
			JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
			file.Close();*/

			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
			container = (Inventory)formatter.Deserialize(stream);
			stream.Close();
		}
	}
	[ContextMenu("Clear")]
	public void Clear()
	{
		container = new Inventory();
	}
}
[System.Serializable]
public class Inventory
{
	public List<InventorySlot> items = new List<InventorySlot>();
}
[System.Serializable]
public class InventorySlot
{
	public int ID;
	public Item item;
	public int amount;
	public InventorySlot(int _id, Item _item, int _amount)
	{
		ID = _id;
		item = _item;
		amount = _amount;
	}
	public void addAmount(int value)
	{
		amount += value;
	}

	public void getAmount(int value) {

		amount -= value;
	
	}
}