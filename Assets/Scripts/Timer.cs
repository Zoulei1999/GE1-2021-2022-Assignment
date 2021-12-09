using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float currentTime = 0f;
    float startTime = 120f;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; // countdown timer
        timerText.text = currentTime.ToString("Time Left: " + "0"); //used to display timer

        if(currentTime <= 0 ){
            currentTime = 0; // prevent timer to go negative
        }
    }
}
