using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
	private Button playButton;
	private Button exitButton;
	private Text textHolder;
	private static string text;

	public static void setText(string t)
    {
        text = t;
    }

	void Start()
	{
		GameObject.FindGameObjectWithTag("ReplayButton").GetComponent<Button>().onClick.AddListener(onReplayClicked);
		GameObject.FindGameObjectWithTag("MainMenuButton").GetComponent<Button>().onClick.AddListener(onMainMenuClicked);
		textHolder = GameObject.FindGameObjectWithTag("GameOverTextHolder").GetComponent<Text>();
	}

	void Update()
	{
		textHolder.text = text;
	}

	private void onReplayClicked()
	{
		SceneManager.LoadScene("mainScene");
	}

	private void onMainMenuClicked()
	{
		SceneManager.LoadScene("mainMenuScene");
	}
}
