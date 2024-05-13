using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    void Update()
    {
        Vector3 translation = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f).normalized;
        translation *= moveSpeed;
        translation *= Time.deltaTime;

        transform.Translate(translation);
    }
}
