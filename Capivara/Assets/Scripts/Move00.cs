using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move00 : MonoBehaviour
{
    [SerializeField] float speed = -2f;
    [SerializeField] float leftBord;
    // Update is called once per frame
    void Start()
    {
        leftBord = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -14.99)
        {
            Destroy(gameObject);
        }
    }
}
