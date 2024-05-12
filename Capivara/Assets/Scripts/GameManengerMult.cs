using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerMult : MonoBehaviour
{
    [SerializeField] private Text scoreText1;
    private int score1;
    [SerializeField] private Text scoreText2;
    private int score2;
    [SerializeField] private GameObject GameOverObj;
    [SerializeField] private GameObject player1Obj; // Variável para registrar o objeto do jogador 1
    [SerializeField] private GameObject player2Obj; // Variável para registrar o objeto do jogador 2
    [SerializeField] private SpawnerMulti barrelSpawner; // Variável para registrar o Spawner de barris

    private bool player1Paused = false; // Variável para controlar o estado do jogador 1
    private bool player2Paused = false; // Variável para controlar o estado do jogador 2

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameOverObj.SetActive(false);
        barrelSpawner.Resume(); // Retoma o Spawner de barris
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se ambos os jogadores estão pausados
        if (player1Paused && player2Paused)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverObj.SetActive(true);
        barrelSpawner.Pause(); // Pausa o Spawner de barris
    }

    public void PausePlayer1()
    {
        player1Paused = true; // Pausa o jogador 1
        player1Obj.SetActive(false); // Desativa o objeto do jogador 1
        if (player2Paused)
        {
            GameOver();
        }
    }

    public void PausePlayer2()
    {
        player2Paused = true; // Pausa o jogador 2
        player2Obj.SetActive(false); // Desativa o objeto do jogador 2
        if (player1Paused)
        {
            GameOver();
        }
    }

    public void RestartButton()
    {
        // Oculta o objeto de Game Over
        GameOverObj.SetActive(false);

        // Reinicia o placar para zero
        score1 = 0;
        score2 = 0;

        // Carrega a cena atual para reiniciar o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Define o tempo para 1 para garantir que o jogo comece imediatamente
        Time.timeScale = 1;

        player1Paused = false; // Reinicia o jogador 1
        player2Paused = false; // Reinicia o jogador 2
        barrelSpawner.Resume(); // Retoma o Spawner de barris

        player1Obj.SetActive(true); // Reativa o objeto do jogador 1
        player2Obj.SetActive(true); // Reativa o objeto do jogador 2
    }

    public bool IsGameOver()
    {
        return player1Paused && player2Paused;
    }

    public void ScoringPlayer1()
    {
        score1 ++;
        scoreText1.text = score1.ToString();
    }

    public void ScoringPlayer2()
    {
        score2 ++;
        scoreText2.text = score2.ToString();
    }
}
