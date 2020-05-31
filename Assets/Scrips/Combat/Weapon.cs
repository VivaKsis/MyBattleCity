using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int firePointId = 0;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnShoot += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot (int id)
    {
        if (id == firePointId)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.OnShoot -= Shoot;
    }
}
