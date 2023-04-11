using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioSource enemyHit;
    public static event Action OnPlayerDeath;
    public hp hp;
    const int MAX_HEALTH = 10;
    public int health;
    float elapsed = 0f;
    public float speed;
    Vector2 movement;
    Rigidbody2D rb;

    int points;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        hp.setMaxHealth(health);
        rb = GetComponent<Rigidbody2D>();
        points = 0;
    }

    public void TakeDamage(int damage){
        enemyHit.Play();
        health -= damage;
        hp.setHealth(health);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (points == 20) {
            SceneManager.LoadScene("Win");
        }
    }

    // Lose health overtime
    public void UpdateHealth(int factor)
    {
      if (factor == 1) {
        health--;
      } else {
        health = MAX_HEALTH;
      }

      hp.setHealth(health);
      
    }
    // This function is called whenever a game object overlaps a trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the game object we overlapped with
        GameObject triggedObject = collision.gameObject;

        // If the game object has the tag "Coin"
        if(triggedObject.CompareTag("Water"))
        {
// Debug.Log() logs a specific message to the console, helping you keep track of what is going on.
            Debug.Log("Water collected");

            UpdateHealth(0);

            audioPlayer.Play();

            // Destory the game object we overlapped with
            Destroy(triggedObject);

            points++;
        }
        if(triggedObject.CompareTag("Bug")){
            //enemyHit.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            UpdateHealth(1);
        }
        if (health <= 0){
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
            SceneManager.LoadScene("Game Over");
        }
    }
}