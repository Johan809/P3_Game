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

    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        Move();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            speed = GetBalloonSpeed();
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            transform.position = temp;
            //Debug.Log(gameObject.name + " " + speed);
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

            PlayerController.IncreaseHelium(IsBalloonBlue(gameObject.name));

            //play explosion sound
            anim.Play("Destroy");
            Invoke("TurnOffGameObject", 0.1f);
        }
    }

    bool IsBalloonBlue(string balloonName) => balloonName == "globo(Clone)";

    float GetBalloonSpeed() => IsBalloonBlue(gameObject.name) //Si el globo es azul
        ? Random.Range(6.5f, 7.5f)
        : Random.Range(3f, 6f);

}
