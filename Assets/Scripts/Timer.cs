using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillFraction;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if (timerValue <= 0 && isAnsweringQuestion) {
            timerValue = timeToShowCorrectAnswer;
            isAnsweringQuestion = false;
        } else if (timerValue <= 0 && !isAnsweringQuestion) {
            timerValue = timeToCompleteQuestion;
            isAnsweringQuestion = true;
            loadNextQuestion = true;
        } else if (timerValue > 0 && isAnsweringQuestion) {
            fillFraction = timerValue / timeToCompleteQuestion;
        } else {
            fillFraction = timerValue / timeToShowCorrectAnswer;
        }


        Debug.Log(timerValue + " " + fillFraction);
    }

}
