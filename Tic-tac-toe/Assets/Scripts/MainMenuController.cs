using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public Button playButton;
	public Button exitButton;

	void Start ()
	{
		GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>().onClick.AddListener(onPlayClicked);
		GameObject.FindGameObjectWithTag("ExitButton").GetComponent<Button>().onClick.AddListener(onExitClicked);
	}

	private void onPlayClicked()
	{
		SceneManager.LoadScene("mainScene");
	}

	private void onExitClicked()
	{
		Application.Quit();
	}
}
