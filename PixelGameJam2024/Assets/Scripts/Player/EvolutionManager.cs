using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    private int evoState = 0;

    public int GetEvoState() { return evoState; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            evoState--;
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
