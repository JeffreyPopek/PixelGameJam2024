using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    [SerializeField] private BulletObjectPool objPool;
    [SerializeField] private BulletObjectPool strongObjPool;
    [SerializeField] private EvolutionManager evoManager;
    [SerializeField] private GameObject spawnLocationMain;
    [SerializeField] private GameObject spawnLocationL;
    [SerializeField] private GameObject spawnLocationR;
    [SerializeField] private float fireRate = 0.5f;
    private float fireTimer = 0.0f;

    private void Update()
    {
        if (fireTimer >= fireRate)
        {
            Fire(evoManager.GetEvoState());
            fireTimer = 0.0f;
        }

        fireTimer += Time.deltaTime;
    }

    private void Fire(int evoState)
    {
        switch (evoState)
        {
            case 0:
                objPool.SpawnBullet(spawnLocationMain);
                break;
            case 1:
                objPool.SpawnBullet(spawnLocationMain);
                objPool.SpawnBullet(spawnLocationL);
                objPool.SpawnBullet(spawnLocationR);
                break;
            case 2:
                strongObjPool.SpawnBullet(spawnLocationMain);
                objPool.SpawnBullet(spawnLocationL);
                objPool.SpawnBullet(spawnLocationR);
                break;
        }
    }
}
