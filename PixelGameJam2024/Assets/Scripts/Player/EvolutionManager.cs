using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    // 0 - Tadpole
    // 1 - Froglet
    // 2 - Frog
    private int evoState = 0;
    private bool isImmune = false;
    [SerializeField] private float immunityTimeMax = 3.0f;
    private float immunityTimer = 0.0f;

    public int GetEvoState() { return evoState; }

    private void Update()
    {
        if (immunityTimer < immunityTimeMax)
        {
            immunityTimer += Time.deltaTime;
        }
        else if (isImmune)
        {
            isImmune = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isImmune)
            {
                evoState--;
                isImmune = true;
                immunityTimer = 0.0f;
            }
        }
        else if (other.gameObject.CompareTag("Powerup"))
        {
            if (evoState < 2)
            {
                evoState++;
            }
        }

        UpdateEvoState();
    }

    private void UpdateEvoState()
    {
        switch (evoState)
        {
            case 0:
                Debug.Log("TADPOLE");
                break;
            case 1:
                Debug.Log("FROGLET");
                break;
            case 2:
                Debug.Log("FROG");
                break;
            default:
                Debug.Log("DEAD");
                break;
        }
    }
}
