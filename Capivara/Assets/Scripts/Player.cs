using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 axis;
    [SerializeField] float gravity = -9f;
    [SerializeField] float force = 5f;
    [SerializeField] float rotationSpeed = 2f;

    private bool isJumping = false;
    private float jumpStartTime;
    public GameManenger gameManger;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.FindObjectOfType<GameManenger>();
    }

    // Update is called once per frame
    void Update()
    {
        axis.y += gravity * Time.deltaTime;
        transform.position += axis * Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            axis = Vector2.up * force;
            isJumping = true;
            jumpStartTime = Time.time;
        }

        if (isJumping)
        {
            // Rotaciona o objeto na direção em que ele está indo
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Rotaciona o objeto de volta à sua orientação original
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacles"))
        {
            gameManger.GameOver();
        }
    }
}
