using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	enum Player { Turbo, Wheel }; 

	private Player?[] choices;

	private Player currentPlayer;

	private Text currentPlayerTextHolder;

	static int[][] winCombinations = new int[][]{
		new int[]{0, 1, 2},
		new int[]{3, 4, 5},
		new int[]{6, 7, 8},
		new int[]{0, 3, 6},
		new int[]{1, 4, 7},
		new int[]{2, 5, 8},
		new int[]{0, 4, 8},
		new int[]{6, 4, 2},
	};

	void Start ()
	{
		currentPlayer = Player.Wheel;
		choices = new Player?[9];
		foreach (var cellObject in GameObject.FindGameObjectsWithTag("Cell"))
		{
			cellObject.GetComponent<CellController>().clear();
		};

		currentPlayerTextHolder = GameObject.FindGameObjectWithTag("CurrentPlayerTextHolder").GetComponent<Text>();
	}

	void Update()
	{
		currentPlayerTextHolder.text = "Current player: " + currentPlayer.ToString();
	}

	public void handleCellClicked(CellController cell)
	{
		var pos = getPos(cell.x, cell.y);
		if (currentPlayer == Player.Wheel)
		{
			cell.addWheel();
			choices[pos] = Player.Wheel;
		}
		else
		{
			cell.addTurbo();
			choices[pos] = Player.Turbo;
		}

		var winner = getWinner();
		if (winner != null)
		{
			GameOverController.setText(winner.ToString() + " won!");
			SceneManager.LoadScene("gameOverScene");
		}
		else if (isAllCellsFilled())
		{
			GameOverController.setText("tie :(");
			
			SceneManager.LoadScene("gameOverScene");
		}

		togglePlayer();
	}

	private Player? getWinner()
	{
		foreach(var item in winCombinations)
		{
			if ((choices[item[0]] != null) && (choices[item[0]] == choices[item[1]]) && (choices[item[1]] == choices[item[2]]))
			{
				return choices[item[0]];
			}
		}

		return null;
	}

	private bool isAllCellsFilled()
	{
		foreach (var item in choices)
		{
			if (item == null)
			{
				return false;
			}
		}

		return true;
	}

	private int getPos(int x, int y)
	{
		return 3 * y + x;
	}

	private void togglePlayer()
	{
		if (currentPlayer == Player.Wheel)
		{
			currentPlayer = Player.Turbo;
		}
		else
		{
			currentPlayer = Player.Wheel;
		}
	}
}
