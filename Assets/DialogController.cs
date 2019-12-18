using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.WebSockets;

public class DialogController : MonoBehaviour
{

    public int points;
    public Dialog[] dialogs;
    private int currentDialogIndex;
    private Text dialogText;
    private GameObject answersPanel;
    private Text answer0Text;
    private Text answer1Text;
    private Text answer2Text;
    private Text answer3Text;
    private GameObject answer0Panel;
    private GameObject answer1Panel;
    private GameObject answer2Panel;
    private GameObject answer3Panel;
    private GameObject background;
    private Text pointsText;
    private bool answersActive;
    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Sprite image6;
    public Sprite image7;
    public Sprite image8;
    public Sprite image9;
    public string[] answers;
    public Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        dialogText=GameObject.Find("Dialog Text").GetComponent<Text>();
        answersPanel=GameObject.Find("Answers Box");
        answer0Panel=GameObject.Find("Answer 0");
        answer1Panel=GameObject.Find("Answer 1");
        answer2Panel=GameObject.Find("Answer 2");
        answer3Panel=GameObject.Find("Answer 3");
        answer0Text=GameObject.Find("Answer 0 Text").GetComponent<Text>();
        answer1Text=GameObject.Find("Answer 1 Text").GetComponent<Text>();
        answer2Text=GameObject.Find("Answer 2 Text").GetComponent<Text>();
        answer3Text=GameObject.Find("Answer 3 Text").GetComponent<Text>();
        background=GameObject.Find("Background");
        pointsText=GameObject.Find("Points").GetComponent<Text>();
        currentDialogIndex=0;
        answersPanel.gameObject.SetActive(false);
        answers=new string[4];

        points=0;
        dialogs=new Dialog[10];
        /*for (int i = 0; i < dialogs.Length; i++)
        {
            dialogs[i]=new Dialog();
        }*/
        dialogs[0]=new Dialog("Nace un lider en la tierra.");
        dialogs[1]=new Dialog("La raza humana no puede diferenciar temprano el alfa de una manada.");
        dialogs[2]=new Dialog("Crece en el entorno de problemática de su región, en pobreza y aprendió de eso.");
        dialogs[3]=new Dialog("En el proceso de compartir y conocer a tu entorno protector, es necesario emplear herramientas ingeniosas para hacer frente a las amenazas que se puedan presentar. Confiar en tus amigos cercanos puede ser la mejor herramienta en situaciones difíciles. ¿Cuál de las siguientes opciones ofrece la posibilidad a tus seres queridos de protegerte en esos momentos?",
        new string[]{"Un sistema de alertas para tu comunidad", "Conseguir un perro fuerte para defenderte", "Aprender a correr más velóz y escapar", "Tener una mejor señal telefónica para llamar a la policía"},"Un sistema de alertas para tu comunidad");
        dialogs[4]=new Dialog("Tu recorrido ha finalizado.");

        dialogText.text=dialogs[currentDialogIndex].text;

        images=new Sprite[10];
        images[0]=image0;
        images[1]=image1;
        images[2]=image2;
        images[3]=image3;
        images[4]=image4;
        images[5]=image5;
        images[6]=image6;
        images[7]=image7;
        images[8]=image8;
        images[9]=image9;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text=points.ToString();
        if (Input.GetKeyDown("space"))
        {
            if (!answersActive)
            {
                NextDialog();
            }
        }
    }

    void NextDialog(){
        currentDialogIndex++;
        background.GetComponent<Image>().sprite=images[currentDialogIndex];
        dialogText.text=dialogs[currentDialogIndex].text;
        if (dialogs[currentDialogIndex].isQuestion)
        {
            answersPanel.gameObject.SetActive(true);
            answer0Text.text=dialogs[currentDialogIndex].answers[0];
            answer1Text.text=dialogs[currentDialogIndex].answers[1];
            answer2Text.text=dialogs[currentDialogIndex].answers[2];
            answer3Text.text=dialogs[currentDialogIndex].answers[3];
            answers[0]=answer0Text.text;
            answers[1]=answer1Text.text;
            answers[2]=answer2Text.text;
            answers[3]=answer3Text.text;
            answersActive=true;
        }
        else{
            answersPanel.gameObject.SetActive(false);
        }
    }

    public void EvaluateAnswer(int answerIndex){
        if (dialogs[currentDialogIndex].correctAnswer==answers[answerIndex])
        {
            points++;
        }
        NextDialog();
    }
}
