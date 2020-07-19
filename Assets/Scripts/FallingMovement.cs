using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float FallingSpeed;

    private float MovementAxis;

    public float SpawnDistance;

    public FallingLevelGenerator LevelGenerator;

    public GameObject PauseCanvas;
    public KeyCode PauseKey;

    public Slider UIslider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        UIslider.maxValue = LevelGenerator.LevelLength * 10;
    }

    void Update()
    {
        MovementAxis = Input.GetAxis("Horizontal");

        if (Input.GetKey(PauseKey))
        {
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }

        UIslider.value = transform.position.y * -1;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(MovementAxis * speed, -FallingSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walls"))
        {
            if(transform.position.y + SpawnDistance >= 0)
            {
                transform.position = new Vector2(0, 2);
            }
            else
            {
                transform.position = new Vector2(0, transform.position.y + SpawnDistance);
            }
        }
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
