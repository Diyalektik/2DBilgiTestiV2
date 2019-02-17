using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IndependentFadeIn : MonoBehaviour {

    Color defaultColor;
    GameObject dataStorage;
    // Use this for initialization
    private void Awake()
    {
        SeasonBreakUpdates.toFadeIn += RunFadeIn;
        SeasonBreakUpdates.toFadeOut += RunFadeOut;
    }
    void Start () {

        dataStorage = GameObject.FindGameObjectWithTag("dataStorage");

        if (gameObject.GetComponent<Image>() != null)
        {
            defaultColor = gameObject.GetComponent<Image>().color;
           
        }
        if (gameObject.GetComponent<Text>() != null)
        {
            defaultColor = gameObject.GetComponent<Text>().color;
            
        }
        
        //StartCoroutine(FadeTextToFullAlpha(0.5f));
    }

    private void OnDestroy()
    {
        SeasonBreakUpdates.toFadeIn -= RunFadeIn;
        SeasonBreakUpdates.toFadeOut -= RunFadeOut;
    }

    public void RunFadeIn()
    {
        StartCoroutine(FadeTextToFullAlpha(1));
    }

    public void RunFadeOut()
    {
        StartCoroutine(FadeTexttoZeroAlpha(1));
    }

    public IEnumerator FadeTexttoZeroAlpha(float t)
    {
       
        if (gameObject.GetComponent<Image>() != null)
        {
            Color i = gameObject.GetComponent<Image>().color;
            i = new Color(i.r, i.g, i.b, 0);
            while (i.a < 1.0f)
            {

                i = new Color(i.r, i.g, i.b, i.a + (Time.deltaTime / t));
                gameObject.GetComponent<Image>().color = i;
                yield return null;
            }
        }
        if (gameObject.GetComponent<Text>() != null)
        {
            Color i = gameObject.GetComponent<Text>().color;
            i = new Color(i.r, i.g, i.b, 0);
            while (i.a < 1.0f)
            {

                i = new Color(i.r, i.g, i.b, i.a + (Time.deltaTime / t));
                gameObject.GetComponent<Text>().color = i;
                yield return null;
            }
        }
        dataStorage.GetComponent<DataStorage>().ChangeSeason();

    }
  

    public IEnumerator FadeTextToFullAlpha(float t)
    {
     
        if (gameObject.GetComponent<Image>() != null)
        {
            Color i = gameObject.GetComponent<Image>().color;
            i = new Color(i.r, i.g, i.b, 0);
            while (i.a < 1.0f)
            {

                i = new Color(i.r, i.g, i.b, i.a + (Time.deltaTime / t));
                gameObject.GetComponent<Image>().color = i;
                yield return null;
            }
            
        }
        if (gameObject.GetComponent<Text>() != null)
        {
            Color i = gameObject.GetComponent<Text>().color;
            i = new Color(i.r, i.g, i.b, 0);
            while (i.a < 1.0f)
            {

                i = new Color(i.r, i.g, i.b, i.a + (Time.deltaTime / t));
                gameObject.GetComponent<Text>().color = i;
                yield return null;
            }
            
        }

    }
}
