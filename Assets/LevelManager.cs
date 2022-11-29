using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public int score = 0;
    public UIController uiController;

    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        uiController.UpdateHealth(playerController.health);
        uiController.UpdateScore(score);
    }

    void Update()
    {
        
    }

    public void UpdateHealth(int newHealth){
        uiController.UpdateHealth(newHealth);
    }

    public void UpdateScore(int newScore){
        uiController.UpdateScore(newScore);
    }

    public void ResetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
