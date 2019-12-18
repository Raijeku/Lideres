using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public string text;
    public bool isQuestion;
    public string[] answers;
    public string correctAnswer;

    public Dialog(string text, string[] answers, string correctAnswer){
        this.text=text;
        this.isQuestion=true;
        this.answers=answers;
        this.correctAnswer=correctAnswer;
    }

    public Dialog(string text){
        this.text=text;
        this.isQuestion=false;
        this.answers=new string[]{"","","",""};
        this.correctAnswer="";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
