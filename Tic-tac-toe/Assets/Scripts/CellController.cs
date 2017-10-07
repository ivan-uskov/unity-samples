using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellController : MonoBehaviour
{
	public int x;
	public int y;

	private GameObject wheel;
	private GameObject turbo;
	private GameObject currentObject;

	private GameController gameController;

	void Start ()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

		wheel = loadResource("wheel");
		turbo = loadResource("turbo");
	}

	private GameObject loadResource(string name)
	{
		var obj = Resources.Load(name) as GameObject;
		if (!obj)
		{
			Debug.Log ("Failed to load " + name);
		}

		return obj;
	}

	void OnMouseDown()
	{
		if (!currentObject)
		{
			gameController.handleCellClicked(this);
		}
	}

	public void addWheel()
	{
		changeObject(wheel);
	}

	public void addTurbo()
	{
		changeObject(turbo);
	}

	public void clear()
	{
		if (currentObject)
		{
			Destroy(currentObject);
			currentObject = null;
		}
	}

	private void changeObject(GameObject obj)
	{
		if (currentObject && currentObject.name != obj.name)
		{
			clear();
		}

		if (!currentObject)
		{
			currentObject = Instantiate(obj, transform.position, Quaternion.identity);
		}
	}
}
