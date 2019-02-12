using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour {


    public string nameOfPlayer;
    public string ageOfPlayer;
    public int currentSeason;


    public Dictionary<int, bool> answerBoolMap = new Dictionary<int, bool>();
    public Dictionary<string, List<string>> questionAnswersMap = new Dictionary<string, List<string>>();

    public List<List<string>> seasonQuestionsList = new List<List<string>>();
    public List<List<string>> seasonAnswersList = new List<List<string>>();

    public List<string> questions1List = new List<string>();
    public List<string> questions2List = new List<string>();
    public List<string> questions3List = new List<string>();
    public List<string> questions4List = new List<string>();

    public List<string> answerList1 = new List<string>();
    public List<string> answerList2 = new List<string>();
    public List<string> answerList3 = new List<string>();
    public List<string> answerList4 = new List<string>();

    string[] tempAnswerArray;

    string[] questions1;
    string[] questions2;
    string[] questions3;
    string[] questions4;
    string[] answers1;
    string[] answers2;
    string[] answers3;
    string[] answers4;

    string getRandomQuestion;
    string getRandomAnswer;
    int randomQuestion;
    int randomAnswer;

  //  Dictionary<soru,Dictionary<4cevap,truefalse>>
   






    void Start () {

        DontDestroyOnLoad(this);

        currentSeason = -1;

        seasonQuestionsList.Add(questions1List);
        seasonQuestionsList.Add(questions2List);
        seasonQuestionsList.Add(questions3List);
        seasonQuestionsList.Add(questions4List);

        seasonAnswersList.Add(answerList1);
        seasonAnswersList.Add(answerList2);
        seasonAnswersList.Add(answerList3);
        seasonAnswersList.Add(answerList4);
       

        questions1 = System.IO.File.ReadAllLines(@"C:\projezaza\SoruCevap\sorular2.txt");
        questions2 = System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\sorularSezon2.txt");
        questions3 = System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\sorularSezon3.txt");
        questions4 = System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\sorularSezon4.txt");

        
        foreach (var question in questions1)
        {
            questions1List.Add(question);
        }
        foreach (var question in questions2)
        {
            questions2List.Add(question);
        }
        foreach (var question in questions3)
        {
            questions3List.Add(question);
        }
        foreach (var question in questions4)
        {
            questions4List.Add(question);
        }

        
        answers1= System.IO.File.ReadAllLines(@"C:\projezaza\SoruCevap\cevaplar2.txt");
        answers2= System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\cevaplarSezon2.txt");
        answers3= System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\cevaplarSezon3.txt");
        answers4= System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\cevaplarSezon4.txt");

        foreach (var answer in answers1)
        {
            answerList1.Add(answer);
        }
        foreach (var answer in answers2)
        {
            answerList2.Add(answer);
        }
        foreach (var answer in answers3)
        {
            answerList3.Add(answer);
        }
        foreach (var answer in answers4)
        {
            answerList4.Add(answer);
        }

       
        
        
        for (int a = 0; a < seasonAnswersList.ToArray().Length; a++)
        {
            
                for (int answerIndex = 0; answerIndex < seasonAnswersList[a].ToArray().Length; answerIndex = answerIndex + 4)
                {

                    
                    tempAnswerArray = new string[] { seasonAnswersList[a][answerIndex],seasonAnswersList[a][answerIndex+1],
                    seasonAnswersList[a][answerIndex + 2],seasonAnswersList[a][answerIndex+3] };
                    questionAnswersMap.Add(seasonQuestionsList[a][answerIndex/4], tempAnswerArray.ToList<string>());
                   // Debug.Log(seasonQuestionsList[a][answerIndex / 4]);

                    

                }
        }
        
        
    }

   
    public void GetUnusedAnswer(int whichSeason, Text questionText, Text aChoice,Text bChoice, Text cChoice,Text dChoice)
    {
        randomQuestion = Random.Range(0, seasonQuestionsList[whichSeason].ToArray().Length);
        getRandomQuestion = (seasonQuestionsList[whichSeason])[randomQuestion];
        
        questionText.text= getRandomQuestion;
        for (int s = 0; s < seasonQuestionsList.ToArray().Length; s++)
        {
            for (int q = 0; q < seasonQuestionsList[s].ToArray().Length; q++)
            {
               
                if (questionText.text == seasonQuestionsList[s][q])
                {
                   
                    aChoice.text = (questionAnswersMap[questionText.text])[0];
                    bChoice.text = (questionAnswersMap[questionText.text])[1];
                    cChoice.text = (questionAnswersMap[questionText.text])[2];
                    dChoice.text = (questionAnswersMap[questionText.text])[3];
                    // getRandomAnswer = seasonAnswersList[s][q * 4];
                }
               
            }
        }
        seasonQuestionsList[whichSeason].RemoveAt(randomQuestion);
    }
    public void ChangeSeason()
    {
        currentSeason++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
