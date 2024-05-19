using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private float diveDelay;
    [SerializeField] private Transform player;
    [SerializeField] private float reticleSpeed;

    private SpriteRenderer spriteRenderer;

    // 0 - Searching
    // 1 - Diving
    // 2 - Stuck
    // 3 - Resetting
    private int behaviourState = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (behaviourState == 0)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 translation = direction * reticleSpeed * Time.deltaTime;

            transform.Translate(translation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (behaviourState == 0)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine("Co_DiveSequence");
            }
        }
    }

    private IEnumerator Co_DiveSequence()
    {
        behaviourState = 1;

        spriteRenderer.color = Color.red;
        gameObject.tag = "Enemy";

        yield return new WaitForSeconds(diveDelay);

        spriteRenderer.color = Color.white;
        gameObject.tag = "Untagged";

        behaviourState = 0;
    }
}
