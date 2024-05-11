using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManenger : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] int score;
    [SerializeField] private GameObject GameOverObj;
    [SerializeField] private GameObject StartObj;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartObj.SetActive (true);
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        GameOverObj.SetActive(false);
        StartObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        GameOverObj.SetActive(true);
    }

    public void RestartButton()
    {
        GameOverObj.SetActive(false);
        SceneManager.LoadScene(0); 
    }
}
