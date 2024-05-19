using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 100f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotation = 0f;
    [SerializeField] private float strength = 2f;

    private float timer = 0;
    private Vector2 spawnPoint;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (timer > lifetime)
        {
            gameObject.SetActive(false);
            Debug.Log("Bullet lifetime expired");
        }
        timer += Time.deltaTime;
    }


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
