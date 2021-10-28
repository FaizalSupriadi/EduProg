using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
	public Formulas formulas;
	int index;
	int score;
	int level;

    // Start is called before the first frame update
    void Start()
    {
        index = -1;
        score = 0;
        level = formulas.getLevel();
    }

    void Win(){
    	score=0;
    	level+=1;
    	formulas.setLevel(level);
    	formulas.Reset();
    	formulas.createGame();
    }

    public void addScore(){
    	score+=1;
    	if(score == 5){
    		Win();
    		Debug.Log("Win");
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
