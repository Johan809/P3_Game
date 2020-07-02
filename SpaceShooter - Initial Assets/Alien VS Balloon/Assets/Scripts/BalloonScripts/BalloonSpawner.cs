using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{

    public float min_X = -6.3f, max_X = 5.5f;
    public GameObject[] balloon_Prefabs;
    

    public float timer = 2f;

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

        if (Random.Range(0, 2)> 0)
        {
            Instantiate(balloon_Prefabs[Random.Range(0, balloon_Prefabs.Length)], temp, Quaternion.identity);
        }

        Invoke("SpawnBalloon", timer);

    }
}
