using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTraveled;
    [SerializeField] Text coinsCollected;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] GameObject gameMusic;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    ShowGameOverScreen();
        //}
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        float roundedDistance = Mathf.Ceil(player.distanceTraveled);
        distanceTraveled.text = ""+ roundedDistance;
        coinsCollected.text = ""+player.collectedCoins;

    }
    public void GameRestart()
      {
        Debug.Log("Restart Game");
        SceneManager.LoadScene("EndlessRunner");
      }
}
