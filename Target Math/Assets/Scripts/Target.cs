using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Target : MonoBehaviour
{
	public GameBehaviour targetB;
	public TMP_Text formulaText;
	RectTransform textT;
	List<string> formulas;
	RectTransform trans;
	int index;
	int level;
    // Start is called before the first frame update
    void Start()
    {
       Init();

    }
    // Get the needed data from the gamebehaviour
    void Init(){
    	level = targetB.getLevel();
    	formulas = targetB.getFormulas();
       	index = targetB.getIndex();
       	formulaText.text = formulas[index];
       	Reset();
    }
    // Check if this target needs to be reset when a new level is created
    void Update(){
    	if(level < targetB.getLevel()){
       		Init();
       		Reset();
    	}
    }
    // Randomly place the target in the given x,y and z coordinates and give it a new formula.
    void Reset(){
    	int x = Random.Range(10,120);
    	int y = Random.Range(-25,-13);
    	int z = Random.Range(10, 40);
    	GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, z);
       	index = targetB.getIndex();
       	formulaText.text = formulas[index];
    }
    // When hit by the gun, check if the index of the gun is the same as this target. If they are, the answer and formula are correct.
    public void Hit(int idx){

    	if(idx == index){
        FindObjectOfType<AudioManager>().Play("TargetRightSfx");
    		targetB.addScore();
    		Debug.Log("Shot!");
    		Reset();
    	}else{
        FindObjectOfType<AudioManager>().Play("TargetWrongSfx");
        Debug.Log("Wrong Answer!");
      }
    }
}
