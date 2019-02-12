using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class SeasonBreakUpdates : MonoBehaviour {

    GameObject dataStorage;
     
    public Button button;

    public static event Action toFadeIn;
    public static event Action toFadeOut;

    

	void Start ()
    {


        dataStorage = GameObject.FindGameObjectWithTag("dataStorage");

        button.GetComponent<Button>().onClick.AddListener(ToFadeOut);
        toFadeIn();
        

    }
    
   

    void ToFadeOut()
    {
        toFadeOut();
    }
    

	
	
}
