using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    private BirdScript bird;


    void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true && bird.birdIsAlive == true)
            spawnProjectile();

        if (transform.position.x > 28.0f)
            Destroy(gameObject);
    }

    void spawnProjectile()
    {
        if (LogicScript.isPaused == false)
            Instantiate(projectile, transform.position, transform.rotation);
    }
}
