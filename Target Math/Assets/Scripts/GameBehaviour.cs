using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This class will define the rules of the game.
public class GameBehaviour : MonoBehaviour
{
	public Formulas formulas;
	public TMP_Text levelText;
	public TMP_Text toNextText;
	public TMP_Text textTimer;
    public TMP_Text finalScore;
    public GameObject gameCanvas;
    public GameObject scoreCanvas;
    public GameObject pauseCanvas;
	int index;
	int score;
	int level;
	int levelLimit = 5; // Starting from level 1
	int minutes = 0;
	int seconds = 0;
	float time = 0.0f;
    bool pause = false;

    // Start is called before the first frame update.
    void Start()
    {

        index = -1;
        score = 0;
        level = formulas.getLevel();
        levelText.text = "Level: " + level.ToString();
        toNextText.text = "Solve 5 Formula";
    }

    // This will handle the timer
    void Update(){
        if(Input.GetKeyDown("escape")){
            if(pause){
                Resume();
                pauseCanvas.SetActive(false);
                gameCanvas.SetActive(true); 
            }else{
                Cursor.lockState = CursorLockMode.None;
                pause = true;
                pauseCanvas.SetActive(true);
                gameCanvas.SetActive(false);        
            }
             
        }
        if(!pause){
        	time += Time.deltaTime;
        	minutes = Mathf.FloorToInt(time / 60.0f);
        	seconds =  Mathf.FloorToInt(time - minutes * 60.0f);
        	textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
    }

    // This will check if the player won, if not the next level is prepared.
    void NextLevel(){
    	score=0;
    	level+=1;

    	if(level >= levelLimit){
    		Win();
    	}
        FindObjectOfType<AudioManager>().Play("NextLevel");
        CreateLevel();

    }
    // Prepare the game to make the level
    void CreateLevel(){
        levelText.text = "Level: " + level.ToString();
        toNextText.text = "Solve 5 Formula";
        formulas.setLevel(level);
        formulas.Reset();
        formulas.createGame();
    }

    // Calculate the score based on time, max score is 100.000, every minute and second will reduce it.
    int CalculateScore(){
    	int maxScore = 100000;
    	int playerScore = maxScore - (minutes * 6000 + seconds * 100);
    	if(playerScore <= 0){
    		playerScore = 0;
    	}
    	return playerScore;
    }

    // If you win, the scoreboard will show up and you can restart the game.
    void Win(){
		Debug.Log("Won!");
        finalScore.text = "Your score is: " + CalculateScore().ToString();
        Cursor.lockState = CursorLockMode.None;
        scoreCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    // Reset the game to default values.
    public void PlayAgain(){
        scoreCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        level = 1;
        minutes = 0;
        seconds = 0;
        time = 0.0f;
        CreateLevel();
    }

    public void addScore(){
    	score+=1;
    	toNextText.text = "Solve " + (5-score).ToString() + " Formula";
    	if(score == 5){
    		NextLevel();
    		Debug.Log("Won this level!");
    	}
    }

    // Used to give a unique formula to each target.
    public int getIndex(){
    	index += 1;
    	if(index >= formulas.formulaLimit){
    		index = 0;
    	}
    	return index;
    }

    public List<string> getFormulas(){
    	return formulas.getFormulas();
    }

    public int getLevel(){
    	return level;
    }

    // Used to go from pause state, back to game state.
    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        pause = false;
    }
}
