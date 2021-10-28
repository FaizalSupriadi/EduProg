using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Target : MonoBehaviour
{
	public TargetBehaviour targetB;
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

    void Init(){
    	level = targetB.getLevel();
    	formulas = targetB.getFormulas();
       	index = targetB.getIndex();
       	formulaText.text = formulas[index];
    }

    void Update(){
    	if(level < targetB.getLevel()){
       		Init();
       		Reset();
    	}
    }

    void Reset(){
    	int x = Random.Range(40,60);
    	int y = Random.Range(-25,-13);
    	int z = Random.Range(10, 20);
    	GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, z);
       	index = targetB.getIndex();
       	formulaText.text = formulas[index];
    }

    public void Hit(int idx){
    	if(idx == index){
    		targetB.addScore();
    		Debug.Log("Shot!");
    		Reset();
    	}
    }
}
