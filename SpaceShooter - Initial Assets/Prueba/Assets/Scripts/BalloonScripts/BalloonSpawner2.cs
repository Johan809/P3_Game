using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner2 : MonoBehaviour
{
    public float min_X = -6.3f, max_X = 5.5f;
    public GameObject BluBalloon;


    public float timer = 1f;

    void Start()
    {
        Invoke("SpawnBalloon", timer);
    }

    // Update is called once per frame
    void SpawnBalloon()
    {

        float pos_X = Random.Range(min_X, max_X);
        Vector3 temp = transform.position;
        temp.x = pos_X;

        Instantiate(BluBalloon, temp, Quaternion.identity);

        Invoke("SpawnBalloon", timer);

    }
}
