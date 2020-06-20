using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotate_speed = 50f;
    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float bound_X = -11f;

    public Transform attack_Point;
    public GameObject bullet_Prefab;

    private Animator anim;
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (canRotate)
        {
            if(Random.Range(0, 2) > 0)
            {
                rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
                rotate_speed *= -1f;
            }
            else
            {
                rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
            }
        }

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if(temp.x < bound_X)
                gameObject.SetActive(false);
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_speed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bullet_Prefab, attack_Point.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().is_EnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

}//class
