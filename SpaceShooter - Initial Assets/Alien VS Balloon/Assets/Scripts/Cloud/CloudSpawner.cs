using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public float min_Y = 3.62f, max_Y = 4.11f;
    public GameObject nubePrefab;
    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnNube", timer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnNube()
    {
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        Instantiate(nubePrefab, temp, Quaternion.Euler(0f, 0f, 0f));
        Invoke("SpawnNube", timer);
    }
}
