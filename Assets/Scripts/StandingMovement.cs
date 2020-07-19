using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StandingMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float JumpSpeed;

    private float MovementAxis;
    private bool isJumping;
    public KeyCode JumpKey;

    private bool OnTheGround;
    public LayerMask Ground;

    public Slider UIslider;

    public GameObject DeathCanvas;

    public GameObject PauseCanvas;
    public KeyCode PauseButton;

    public StandingLevelGenerator LevelGenerator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UIslider.maxValue = LevelGenerator.LevelLength * 10;
    }

    void Update()
    {
        MovementAxis = Input.GetAxis("Horizontal");

        if (Input.GetKey(JumpKey) && OnTheGround)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (GetComponentInChildren<BoxCollider2D>().IsTouchingLayers(Ground))
        {
            OnTheGround = true;
        }
        else
        {
            OnTheGround = false;
        }

        if (Input.GetKey(PauseButton))
        {
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }

        UIslider.value = transform.position.y;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(MovementAxis * speed, rb.velocity.y);

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            Time.timeScale = 0;
            DeathCanvas.SetActive(true);
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
