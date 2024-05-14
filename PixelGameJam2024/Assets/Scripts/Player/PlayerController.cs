using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 boundary;

    void Update()
    {
        Vector3 translation = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f).normalized;
        translation *= moveSpeed;
        translation *= Time.deltaTime;

        Vector3 boundaryCheck = transform.position + new Vector3(translation.x, translation.y, 0);

        if (boundaryCheck.x < boundary.x && 
            boundaryCheck.x > -boundary.x && 
            boundaryCheck.y < boundary.y && 
            boundaryCheck.y > -boundary.y)
        {
            transform.Translate(translation);
        }
    }
}
