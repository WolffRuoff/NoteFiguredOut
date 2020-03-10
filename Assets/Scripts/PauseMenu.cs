// <copyright file="PauseMenu.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>14/08/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Pause menu script. Provides functionality to Pause and Unpause the game and Go Back to the Main Menu. Controlled by buttons from the Unity UI.
/// Pressing ESC will also open and close the menu.
/// </summary>
public class PauseMenu : MonoBehaviour {


	public string mainMenuScene = "StartMenu";
    private GameObject pauseMenuCanvas;

	private bool running;

    void Start()
    {
		pauseMenuCanvas = GameObject.Find("Pause Screen");
		pauseMenuCanvas.SetActive(false);
		running = true;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			if (running) {
				Pause();
			}
			else if (running==false) {
				UnPause();
			}
		}
	}

	public void Pause(){
		pauseMenuCanvas.SetActive (true);
		Time.timeScale = 0;
		running = false;
		GameManager.Pause();
	}

	public void UnPause(){
		pauseMenuCanvas.SetActive (false);
		Time.timeScale = 1;
		running = true;
		GameManager.Unpause();
	}

	public void GoToMainMenu(){
		GameManager.gameState = GameManager.GameState.StartMenu;
		GameManager.LoadScene (mainMenuScene);
	}

    public void OnClick()
    {
		if (running)
		{
			Pause();
		}
		else if (running == false)
		{
			UnPause();
		}
	}
}
