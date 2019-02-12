using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour {

    GameObject dataStorage;

    public Text presenterText;
    public int textIndex=0;
    public string[] hangitextyazılsınistiyoruz;
    public int hangitextindex=0;

    public InputField inputField;
    public Text inputFieldText;
    public Button myNameIsButton;

    private void Start()
    {
        dataStorage = GameObject.FindGameObjectWithTag("dataStorage");
        inputField.interactable = false;
        myNameIsButton.interactable = false;
        StartCoroutine(TextFadeInOneByOne());
    }

    IEnumerator TextFadeInOneByOne()
    {

        while (hangitextindex<hangitextyazılsınistiyoruz.Length)
        {
            gameObject.GetComponent<Text>().text = "";
            while (textIndex < hangitextyazılsınistiyoruz[hangitextindex].Length)
            {

                gameObject.GetComponent<Text>().text += hangitextyazılsınistiyoruz[hangitextindex][textIndex];

                yield return new WaitForSeconds(0.1f);
                textIndex++;
                
            }
            textIndex = 0;
            
            yield return new WaitForSeconds(0.1f);
            
            hangitextindex++;
        }
        inputField.interactable = true;
        myNameIsButton.interactable = true;
        myNameIsButton.GetComponentInChildren<Text>().text = "Adım: ";
        
       

        yield return null;
    }

    public void DeactivateInputField()
    {
        dataStorage.GetComponent<DataStorage>().nameOfPlayer = inputFieldText.text;
        inputField.interactable = false;
    }
   

  

   
}
