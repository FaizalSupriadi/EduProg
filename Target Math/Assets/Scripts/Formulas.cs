using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateFormula{
	private List<float> answers = new List<float>();
    private List<string> formulas = new List<string>();

    public void Reset(){
    	answers = new List<float>();
    	formulas = new List<string>();
    }

	public void createAdd(float x, float y){
		answers.Add(x + y);
		formulas.Add(x.ToString() + " + " + y.ToString());
	}
	public void createMin(float x,float y){
		answers.Add(x - y);
		formulas.Add(x.ToString() + " - " + y.ToString());
	}
	public void createMul(float x,float y){
		answers.Add(x * y);
		formulas.Add(x.ToString() + " * " + y.ToString());
	}
	public void createDiv(float x,float y){
		answers.Add(x / y);
		formulas.Add(x.ToString() + " / " + y.ToString());
	}

	public List<float> getAnswers(){ 
		return answers;
	}
	public List<string> getFormulas(){
		return formulas;
	}
}

public class Formulas : MonoBehaviour
{
    // Start is called before the first frame update
    public int level = 1;
    public int formulaLimit = 10;

    private TemplateFormula template;
    public void Start()
    {
        template = new TemplateFormula();
		createGame();

		// List<float> ans = getAnswers();
		// List<string> form = getFormulas();
		// foreach (float answer in ans)  
  //       {  
  //           Debug.Log(answer); 
  //       }
		// foreach (string f in form)  
  //       {  
  //           Debug.Log(f); 
  //       }
    }

    public void setLevel(int lvl){
    	level = lvl;
    }
    public void setLimit(int limit){
    	formulaLimit = limit;
    }

    public void Reset(){
    	template.Reset();
    }

    public void createGame(){
    	for (int i = 0; i < formulaLimit; i++){
          int x = Random.Range(1,99);
          int y = Random.Range(1,99);
          int lvl = Random.Range(1, level+1);
		  if(lvl == 1){
		  	template.createAdd(x,y);
		  }
		  else if(lvl == 2){
		  	template.createMin(x,y);
		  }
		  else if(lvl == 3){
		  	template.createMul(x,y);
		  }
		  else if(lvl >= 4){
		  	template.createDiv(x,y);
		  }
		}
    }

	public List<float> getAnswers(){ 
		return template.getAnswers();
	}
	public List<string> getFormulas(){
		
		return template.getFormulas();
	}

	public int getLevel(){
		return level;
	}

}
