using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour {

    public Button playButton;
    public Button shopButton;
    public Button rankingButton;
    

    void Start () {
	   
        
	}
	
    public void ChangeScenePlusOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	

}
