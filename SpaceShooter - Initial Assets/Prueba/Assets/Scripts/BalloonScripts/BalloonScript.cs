using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public float speed = 1f;
    private bool canMove = true;
    public float bound_Y = 5f;

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
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y > bound_Y)
                gameObject.SetActive(false);
        }
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    //Si el objeto tiene el tag 'Enemy' y lo impacta una bala este se destruira, 
    //debe tener el tag y la animacion se debe llamar 'Destroy', 
    //tambien se le puede agregar el sonido de explosion
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            canMove = false;

            Invoke("TurnOffGameObject", 3f);

            //play explosion sound
            anim.Play("Destroy");
        }
    }



}
