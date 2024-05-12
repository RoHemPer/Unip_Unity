using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private Vector3 axis;
    [SerializeField] private float gravity = -9f;
    [SerializeField] private float force = 5f;
    [SerializeField] private float rotationSpeed = 2f; // Velocidade de rotação inicial

    private float jumpStartTime;
    private float rotationSpeedIncreaseInterval = 2f; // Intervalo para aumentar a velocidade de rotação
    private float lastRotationSpeedIncreaseTime; // Última vez que a velocidade de rotação foi aumentada
    public GameManagerMult gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManagerMult>();
        lastRotationSpeedIncreaseTime = Time.time; // Inicializa o contador
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o jogo está pausado (no estado de "Game Over")
        if (!gameManager.IsGameOver())
        {
            axis.y += gravity * Time.deltaTime;
            transform.position += axis * Time.deltaTime;

            // Adiciona suporte para entrada de toque
            if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                axis = Vector2.up * force;
                jumpStartTime = Time.time;
            }

            // Rotaciona o objeto na direção em que ele está indo
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            // Verifica se já passaram 2 segundos desde o último aumento de velocidade
            if (Time.time - lastRotationSpeedIncreaseTime >= rotationSpeedIncreaseInterval)
            {
                rotationSpeed++; // Aumenta a velocidade de rotação
                lastRotationSpeedIncreaseTime = Time.time; // Atualiza o contador
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacles"))
        {
            gameManager.PausePlayer1(); // Pausa o jogador 1
        }
        if(collision.CompareTag("Scoring"))
        {
            gameManager.ScoringPlayer1(); // Pontua para o jogador 1
        }
    }
}
