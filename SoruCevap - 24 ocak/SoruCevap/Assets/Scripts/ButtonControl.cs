using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class ButtonControl : MonoBehaviour {

  //  public static event Action<IEnumerator> SceneFadeOut = delegate { };
  
    Button aButton;
    Button bButton;
    Button cButton;
    Button dButton;

    List<Button> buttonList;
    List<Text> textList;
    int randomTextListIndex;

    Text tempText1;
    Text tempText2;
    Text tempText3;
    Text tempText4;

    Text aText;
    Text bText;
    Text cText;
    Text dText;

    Text questionText;
    int randQuestion;
    GameObject dataStorage;
    GameObject panel;

    int currentSeason;

    Color defaultColor;

    public static event Action toFadeOut;
    public static event Action toFadeIn;

    void Start () {

        panel = GameObject.FindGameObjectWithTag("Panel");
        dataStorage = GameObject.FindGameObjectWithTag("dataStorage");
        aButton = GameObject.FindGameObjectWithTag("aButton").GetComponent<Button>();
        bButton = GameObject.FindGameObjectWithTag("bButton").GetComponent<Button>();
        cButton = GameObject.FindGameObjectWithTag("cButton").GetComponent<Button>();
        dButton = GameObject.FindGameObjectWithTag("dButton").GetComponent<Button>();
        questionText = GameObject.FindGameObjectWithTag("questionText").GetComponent<Text>();
        aText = GameObject.FindGameObjectWithTag("aText").GetComponent<Text>();
        bText = GameObject.FindGameObjectWithTag("bText").GetComponent<Text>();
        cText = GameObject.FindGameObjectWithTag("cText").GetComponent<Text>();
        dText = GameObject.FindGameObjectWithTag("dText").GetComponent<Text>();

        
      

        currentSeason = dataStorage.GetComponent<DataStorage>().currentSeason;
        toFadeIn();

        PrepareQuestions();
        
    }

   

    IEnumerator CorrectAnswer(Button choiceButton)
    {

        defaultColor = choiceButton.GetComponent<Image>().color;
        choiceButton.GetComponent<Image>().color = Color.yellow;
        /*
        foreach (var button in buttonList)
        {
            button.interactable = false;
            
        } */

        yield return new WaitForSeconds(1);

        choiceButton.GetComponent<Image>().color = Color.green;

        yield return new WaitForSeconds(1);

        //fadeout
        toFadeOut();
       

        yield return new WaitForSeconds(1);

        foreach (var button in buttonList)
        {
            button.interactable = true;
            button.GetComponent<Image>().color = defaultColor;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
    IEnumerator WrongAnswer(Button choiceButton)
    {
        defaultColor = choiceButton.GetComponent<Image>().color;
        choiceButton.GetComponent<Image>().color = Color.yellow;

        foreach (var button in buttonList)
        {
            button.interactable = false;

        }

        yield return new WaitForSeconds(1);

        choiceButton.GetComponent<Image>().color = Color.red;

        yield return new WaitForSeconds(1);

        foreach (var button in buttonList)
        {
            button.interactable = true;
            button.GetComponent<Image>().color= defaultColor;
        }
         

        yield return null;

    }
    void ChoiceClick(Button button, Text text)
    {
        foreach (var question in dataStorage.GetComponent<DataStorage>().questionAnswersMap.Keys)
        {
            if (questionText.text==question)
            {
                foreach (var answer in dataStorage.GetComponent<DataStorage>().questionAnswersMap[question])
                {
                    Debug.Log(answer);
                    if (answer==text.text)
                    {
                        if (answer== dataStorage.GetComponent<DataStorage>().questionAnswersMap[question][0])
                        {    //cevap dogruysa
                            StartCoroutine(CorrectAnswer(button));
                            
                        }
                        else
                        {
                            StartCoroutine(WrongAnswer(button));       
                        }
                    }
                }
            }
        }
        
    }

	void PrepareQuestions()
    {
        buttonList = new List<Button>();
        buttonList.Add(aButton);
        buttonList.Add(bButton);
        buttonList.Add(cButton);
        buttonList.Add(dButton);

        textList = new List<Text>();
        textList.Add(aText);
        textList.Add(bText);
        textList.Add(cText);
        textList.Add(dText);



        randomTextListIndex = UnityEngine.Random.Range(0, textList.ToArray().Length);
        tempText1 = textList[randomTextListIndex];
        textList.RemoveAt(randomTextListIndex);
        randomTextListIndex = UnityEngine.Random.Range(0, textList.ToArray().Length);
        tempText2 = textList[randomTextListIndex];
        textList.RemoveAt(randomTextListIndex);
        randomTextListIndex = UnityEngine.Random.Range(0, textList.ToArray().Length);
        tempText3 = textList[randomTextListIndex];
        textList.RemoveAt(randomTextListIndex);
        randomTextListIndex = UnityEngine.Random.Range(0, textList.ToArray().Length);
        tempText4 = textList[randomTextListIndex];
        textList.RemoveAt(randomTextListIndex);

        
        GetUnusedAnswers(currentSeason,questionText, tempText1, tempText2, tempText3, tempText4);


        aButton.onClick.AddListener(() => ChoiceClick(aButton, aText));
        bButton.onClick.AddListener(() => ChoiceClick(bButton, bText));
        cButton.onClick.AddListener(() => ChoiceClick(cButton, cText));
        dButton.onClick.AddListener(() => ChoiceClick(dButton, dText));

    }
    
    void GetUnusedAnswers(int whichSeason ,Text questionText, Text aChoice,Text bChoice,Text cChoice,Text dChoice)
    {
        dataStorage.GetComponent<DataStorage>().GetUnusedAnswer(whichSeason, questionText, aChoice, bChoice, cChoice, dChoice);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
