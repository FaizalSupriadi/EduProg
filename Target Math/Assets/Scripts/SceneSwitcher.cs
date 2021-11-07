using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// This class will handle the switching between menu and the game.
public class SceneSwitcher : MonoBehaviour
{
	public void playGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void back(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void quit(){
		Debug.Log("QUIT");
		Application.Quit();
	}

	public void buttonSound(){
		FindObjectOfType<AudioManager>().Play("Button1");
	}
}
