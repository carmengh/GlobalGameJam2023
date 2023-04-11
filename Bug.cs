using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    
    public int damage;
    public Player playerHealth;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(damage);
        }
    }
    public float moveSpeed = 10;
    Rigidbody2D rb;
    private Transform target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveDirection = direction;
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    private void FixUpdate(){
        moveCharacter(moveDirection);
    }
}
