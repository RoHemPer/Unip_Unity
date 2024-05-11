using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x <= -14.99)
        {
            Destroy(gameObject);
        }
    }
}

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject barrilprefab;
    [SerializeField] float time = 2f;
    [SerializeField] float minY = -2f, maxY = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), time, time); 
    }

    void Spawn()
    {
        GameObject newBarril = Instantiate(barrilprefab, transform.position, Quaternion.identity);
        newBarril.AddComponent<Move00>();
        newBarril.transform.position += new Vector3(0, Random.Range(minY, maxY));
    }
}
