using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;
    [SerializeField] private GameObject GameOverObj;
    [SerializeField] private Spawner spawner; // Adicionado o Spawner

    private bool gamePaused = false; // Variável para controlar o estado do jogo

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameOverObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o jogo está pausado antes de atualizar o placar
        if (!gamePaused)
        {
        
        }
    }

    public void GameOver()
    {
        GameOverObj.SetActive(true);
        gamePaused = true; // Define o estado do jogo como pausado quando o jogo termina
        spawner.Pause(); // Pausa o Spawner quando o jogo termina
    }

    public void RestartButton()
    {
        // Oculta o objeto de Game Over
        GameOverObj.SetActive(false);

        // Reinicia o placar para zero
        score = 0;

        // Carrega a cena atual para reiniciar o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Define o tempo para 1 para garantir que o jogo comece imediatamente
        Time.timeScale = 1;

        gamePaused = true; // Pausa o jogo ao reiniciar
        spawner.Resume(); // Retoma o Spawner quando o jogo reinicia
    }

    public bool IsGameOver()
    {
        return gamePaused;
    }

    public void Scoring()
    {
        score ++;
        scoreText.text = score.ToString();
    }
}
