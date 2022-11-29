using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    public TMP_Text health;
    public TMP_Text score;

    public void UpdateHealth(int newHealth){
        health.text = "" + newHealth;
    }

    public void UpdateScore(int newScore){
        score.text = "" + newScore;
    }
}
