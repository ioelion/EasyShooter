using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeflow : MonoBehaviour
{
    public float minTimeScale = 0f;
    public float maxTimeScale = 1f;
    public float maxMouseTimeScale = 0.4f;

    public float scaleTransitionSpeed = 0.05f;
    public PlayerController playerController;
    private bool timeStopped = false;
    void Update()
    {
        if(playerController.WantsToMove()){
            StartTime(maxTimeScale);
        }else if(playerController.WantsToLook()){
            StartTime(maxMouseTimeScale);
        } else{
            StopTime();
        }
    }

    private void StartTime(float toTimeScale){
        timeStopped = false;
        float _timeScale = Time.timeScale;
        Time.timeScale = Mathf.Lerp(_timeScale, toTimeScale, scaleTransitionSpeed);
        Time.fixedDeltaTime = 0.01F * Time.timeScale;
    }

    private void StopTime(){
        timeStopped = true;
        float _timeScale = Time.timeScale;
        Time.timeScale = Mathf.Lerp(_timeScale,minTimeScale, scaleTransitionSpeed * 2);
        Time.fixedDeltaTime = 0.01F * Time.timeScale;
    }
}
