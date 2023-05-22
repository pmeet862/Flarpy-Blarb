using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    private LogicScript logic;
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private GameObject pipe2;
    private float spawnRate;
    private float timer = 0;
    private float timer2 = 0;

    [SerializeField]
    private float heightOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = logic.spawnInterval;

        if (timer < spawnRate && LogicScript.isPaused == false)
        {
            timer = timer + Time.deltaTime;
            timer2 = timer2 + Time.deltaTime;
        }
        else if (timer2 >= 10f)
        {
            spawnPipe2();
            timer = 0;
            timer2 = 0;
        }
        else if (timer > spawnRate)
        {
            spawnPipe();
            timer = 0;
        }

    }

    void spawnPipe()
    {
        if (LogicScript.isPaused == false)
        {
            float lowestPoint = transform.position.y - heightOffset;
            float highestPoint = transform.position.y + heightOffset;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }

    }
    void spawnPipe2()
    {
        if (LogicScript.isPaused == false)
            Instantiate(pipe2, transform.position, transform.rotation);

    }
}
