using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudoSom : MonoBehaviour
{
    [SerializeField] AudioSource Mudo;

    // Variável estática para a instância atual do AudioSource
    public static AudioSource currentAudioSource = null;

    void Awake()
    {
        // Obtém o nome da cena atual
        string sceneName = SceneManager.GetActiveScene().name;

        // Verifica se a cena atual é "Inicio"
        if (sceneName == "Inicio")
        {
            // Se for, interrompe todos os processos
            StopAllCoroutines();

            // Destroi o objeto de áudio anterior
            if (currentAudioSource != null)
            {
                Destroy(currentAudioSource.gameObject);
                currentAudioSource = null;
            }
        }

        // Se currentAudioSource for nulo, esta instância se torna a instância atual do AudioSource
        if (currentAudioSource == null)
        {
            // Cria um novo GameObject "PersistentAudio" se ele não existir
            GameObject root = GameObject.Find("PersistentAudio");
            if (root == null)
            {
                root = new GameObject("PersistentAudio");
                DontDestroyOnLoad(root);
            }

            // Move o AudioSource para o GameObject "PersistentAudio"
            Mudo.transform.SetParent(root.transform);

            // Esta instância se torna a instância atual do AudioSource
            currentAudioSource = Mudo;

            // Carrega o estado do som das preferências do jogador
            bool EstadoSom = PlayerPrefs.GetInt("EstadoSom", 1) == 1;
            Mudo.enabled = EstadoSom;

            // Se o som estiver habilitado, começa a tocar a música
            if (EstadoSom)
            {
                Mudo.Play();
            }
        }
    }
    
    public void LigarDesligarSom()
    {
        // Inverte o estado do som
        bool EstadoSom = !Mudo.isPlaying;
        Mudo.enabled = EstadoSom;

        // Salva o estado do som nas preferências do jogador
        PlayerPrefs.SetInt("EstadoSom", EstadoSom ? 1 : 0);

        // Se o som estiver habilitado, começa a tocar a música
        if (EstadoSom)
        {
            Mudo.Play();
        }
        else
        {
            Mudo.Stop();
        }
    }
}
