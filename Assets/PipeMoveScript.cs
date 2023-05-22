using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    private LogicScript logic;
    private float moveSpeed1;
    [SerializeField]
    private float pipeOpenSpeed = 8.0f;
    [SerializeField]
    private float deadZone = -27f;
    [SerializeField]
    private GameObject topPipe;
    [SerializeField]
    private GameObject bottomPipe;
    [SerializeField]
    private GameObject target;



    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicScript.isPaused == true)
        {
            moveSpeed1 = 0f;
        }
        else
        {
            moveSpeed1 = logic.moveSpeed;
        }

        transform.position = transform.position + (Vector3.left * moveSpeed1) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 21.0f && LogicScript.isPaused == true)
        {
            Destroy(gameObject);
        }

    }

    [ContextMenu("Open Pipe")]
    public void openPipe()
    {
        float verticalPos = 0f;
        while (verticalPos < 50f)
        {
            topPipe.transform.position = topPipe.transform.position + (Vector3.up * pipeOpenSpeed) * Time.deltaTime;
            bottomPipe.transform.position = bottomPipe.transform.position + (Vector3.down * pipeOpenSpeed) * Time.deltaTime;
            verticalPos++;
        }

    }

}
