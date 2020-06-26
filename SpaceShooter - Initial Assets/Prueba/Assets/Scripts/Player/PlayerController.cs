using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Text restartText;
    private bool restart;
    public Text gameOverText;
    private bool gameOver;

    void Start()
    {
        restart = false;
        restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false); 
        current_Attack_Timer = attack_Timer;
        updateHeliumScore();
    }

    void Update()
    {
        MovePlayer();
        Attack();
        remove5HeliumAfter10Secs();
        FinishGameWhenHeliumIs0();
        if (restart && Input.GetKeyDown(KeyCode.R)) Restart();
    }

    void MovePlayer()
    {
        if(Input.GetAxisRaw("Vertical") > 0f) {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_Y)
                
                GameOver();
            
            transform.position = temp;
        } else if(Input.GetAxisRaw("Vertical") < 0f) {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y)
                
                GameOver();
            
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

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        gameObject.AddComponent<Timer>().ResetTimer();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = (true);
        if (gameOver)
        {
            restartText.gameObject.SetActive(true);
            restart = true;
            Time.timeScale = 0f;
        }
    }

    void FinishGameWhenHeliumIs0() { if (helium < 1) GameOver(); }

}//class
