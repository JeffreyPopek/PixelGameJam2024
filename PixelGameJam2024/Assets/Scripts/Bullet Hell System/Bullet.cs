using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 100f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotation = 0f;
    [SerializeField] private float strength = 2f;

    private float timer = 0;
    private Vector2 spawnPoint;

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (timer > lifetime)
        {
            gameObject.SetActive(false);
            //transform.position = Movement(timer);
            Debug.Log("Bullet lifetime expired");
        }
        timer += Time.deltaTime;
    }
    
    // private Vector2 Movement(float timer) {
    //     // Moves right according to the bullet's rotation
    //     float x = timer * speed * transform.right.x;
    //     float y = timer * speed * transform.right.y;
    //     return new Vector2(x+spawnPoint.x, y+spawnPoint.y);
    // }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
            Debug.Log("Hit Wall");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hit Wall");

        if (col.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
            Debug.Log("Destroying Bullet");
        }
    }
}
