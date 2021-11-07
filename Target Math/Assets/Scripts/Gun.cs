using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class will handle the interaction between the object shot and the current answer.
public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public Formulas formulas;
    public Text currentAnswer;

    List<float> answers;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        answers = formulas.getAnswers();
    }

    // This will check if the player scrolls and will change the current answer.
    void Update()
    {
        answers = formulas.getAnswers();
        currentAnswer.text = "Answer: " + answers[index].ToString();
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
            if(Input.GetAxis("Mouse ScrollWheel") > 0){
                index+=1;
                if(index > answers.Count-1){
                    index = 0;
                    }
                    currentAnswer.text = "Answer: " + answers[index].ToString();
                }else if(Input.GetAxis("Mouse ScrollWheel") < 0){
                    index-=1;
                    if(index < 0){
                        index = answers.Count-1;
                    }
                    currentAnswer.text = "Answer: " + answers[index].ToString();    
                }                                        

    }
    // This function will shoot a raycast, if it hits an object of the correct type, it will use its Hit() function.
    void Shoot(){
        FindObjectOfType<AudioManager>().Play("gunSfx");
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit )){
            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.Hit(index);
            }
        }
    }
}
