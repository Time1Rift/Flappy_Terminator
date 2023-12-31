using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    private List<SpawnerEnemies> _poolsEnemy = new();
    private List<SpawnerBullets> _poolsBullet = new();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out SpawnerEnemies componentEnemy))
            {
                _poolsEnemy.Add(componentEnemy);
            }
            else if(transform.GetChild(i).TryGetComponent(out SpawnerBullets componentBullet))
            {
                _poolsBullet.Add(componentBullet);
            }
        }
    }    

    public void LaunchEnemies()
    {
        foreach (SpawnerEnemies pool in _poolsEnemy)
            pool.LaunchLiberationEnemies();
    }

    public void Restart()
    {
        foreach (SpawnerEnemies pool in _poolsEnemy)
        {
            pool.StopReleaseEnemy();
            pool.Restart();
        }

        foreach (SpawnerBullets pool in _poolsBullet)
            pool.Restart();        
    }
}