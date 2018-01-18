using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	const int greenBlockSizes = 10;

	private GameObject greenBlock;
	private GameObject[] greenBlocks = new GameObject[greenBlockSizes];

	void Start () {
		greenBlock = loadResource("Brick");

		var pos = new Vector3(-5, 2, 0);
		for (int i = 0; i < greenBlockSizes; ++i)
		{
			greenBlocks[i] = Instantiate(greenBlock, pos, Quaternion.identity);
			pos.x += 1.2f;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	private GameObject loadResource(string name)
	{
		var obj = Resources.Load(name) as GameObject;
		if (!obj)
		{
			Debug.Log("Failed to load " + name);
		}

		return obj;
	}
}
