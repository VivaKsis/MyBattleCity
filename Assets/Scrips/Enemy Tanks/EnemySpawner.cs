using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject tankSpawned;

    public GameObject [] spawnPoints;

    private int instanceNumber = 1;

    public void SpawnEnemy ()
    {
        foreach(GameObject sp in spawnPoints)
        {
            GameObject obj = Instantiate(tankSpawned, sp.transform.position, Quaternion.identity);
            obj.name = tankSpawned.name + " " + instanceNumber;
            
            Weapon weapon = obj.GetComponentInChildren<Weapon>();
            weapon.firePointId = instanceNumber+1;
            instanceNumber++;
        }
    }

    private void Start()
    {
        SpawnEnemy();
    }
}
