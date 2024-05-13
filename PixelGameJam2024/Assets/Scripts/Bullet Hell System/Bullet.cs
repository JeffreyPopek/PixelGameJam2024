using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotation = 0f;

    private float timer = 0;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (timer > lifetime)
        {
            gameObject.SetActive(false);
            Debug.Log("Bullet lifetime expired");
        }
        timer += Time.deltaTime;
    }
}
