using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;

    public GameObject fireEffect = default;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRateMin = Random.Range(spawnRateMin, spawnRateMax);

        // FindObjectOfType은 사용하지 않는다. 쉽게 사용할 수 있기 떄문에 예제로 사용하는 것.
        target = FindObjectOfType<PlayerController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(spawnRate <= timeAfterSpawn )
        {
            timeAfterSpawn = 0f;

            this.transform.LookAt(target);

            GameObject effect = Instantiate(fireEffect, this.transform.position, this.transform.rotation);
            Destroy(effect, 0.5f);

            GameObject bullet = Instantiate(bulletPrefab,this.transform.position,this.transform.rotation);
            //bullet.transform.LookAt(target);



            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
