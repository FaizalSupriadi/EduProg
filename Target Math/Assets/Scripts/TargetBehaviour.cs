using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TargetBehaviour : MonoBehaviour
{
	public Formulas formulas;
	public TMP_Text levelText;
	public TMP_Text toNextText;
	public TMP_Text textTimer;
	int index;
	int score;
	int level;
	int levelLimit = 5; // Starting from level 1
	int minutes = 0;
	int seconds = 0;
	float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        index = -1;
        score = 0;
        level = formulas.getLevel();
        levelText.text = "Level: " + level.ToString();
        toNextText.text = "Solve 5 Formula";
    }

    void Update(){
    	time += Time.deltaTime;
    	minutes = Mathf.FloorToInt(time / 60.0f);
    	seconds =  Mathf.FloorToInt(time - minutes * 60.0f);
    	textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void NextLevel(){
    	score=0;
    	level+=1;
    	if(level >= levelLimit){
    		Win();
    	}
    	levelText.text = "Level: " + level.ToString();
        toNextText.text = "Solve 5 Formula";
    	formulas.setLevel(level);
    	formulas.Reset();
    	formulas.createGame();
    }

    int CalculateScore(){
    	int maxScore = 10000;
    	int playerScore = maxScore - (minutes * 1000 + seconds * 100);
    	if(playerScore <= 0){
    		playerScore = 0;
    	}
    	return playerScore;
    }

    void Win(){
    	Debug.Log(CalculateScore());
		Debug.Log("Won!");
    }

    public void addScore(){
    	score+=1;
    	toNextText.text = "Solve " + (5-score).ToString() + " Formula";
    	if(score == 5){
    		NextLevel();
    		Debug.Log("Won this level!");
    	}
    }

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

}
