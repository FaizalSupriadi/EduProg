using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public Formulas formulas;
    public Text currentAnswer;

    List<float> answers;
    int index = 0;
    bool changeAnswer = false;
    // Start is called before the first frame update
    void Start()
    {
        answers = formulas.getAnswers();
    }

    // Update is called once per frame
    void Update()
    {
        answers = formulas.getAnswers();
        currentAnswer.text = answers[index].ToString();
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
        // else if(Input.GetKeyDown("left ctrl")){
        //     changeAnswer = true; 
        // }        
        // else if(Input.GetKeyUp("left ctrl")){
        //     changeAnswer = false; 
        // }
        // if(changeAnswer){
            if(Input.GetAxis("Mouse ScrollWheel") > 0){
                index+=1;
                if(index > answers.Count-1){
                    index = 0;
                    }
                    currentAnswer.text = answers[index].ToString();
                }else if(Input.GetAxis("Mouse ScrollWheel") < 0){
                    index-=1;
                    if(index < 0){
                        index = answers.Count-1;
                    }
                    currentAnswer.text = answers[index].ToString();    
                }                                        
         // }
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit )){
            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.Hit(index);
            }
        }
    }
}
