using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float min_Y, max_Y;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;

    public int helium = 100;
    public Text score;

    private float time = 0.0f;
    private float period = 10f;

    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_Timer;
        updateHeliumScore();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
        remove5HeliumAfter10Secs();
    }

    void MovePlayer()
    {
        if(Input.GetAxisRaw("Vertical") > 0f) {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_Y)
                temp.y = max_Y;

            transform.position = temp;
        } else if(Input.GetAxisRaw("Vertical") < 0f) {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y)
                temp.y = min_Y;

            transform.position = temp;
        }
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;

        if(attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                // play the sound fx
            }
        }

    }

    void remove5HeliumAfter10Secs()
    {
        time += Time.deltaTime;
        if (time >= period)
        {
            time -= period;
            helium -= 5;
            updateHeliumScore();
        }
    }

    void updateHeliumScore() => score.text = helium.ToString("000000");



}//class
