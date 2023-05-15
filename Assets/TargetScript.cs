using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject currentPipe;

    private PipeMoveScript pipeMove;
    // Start is called before the first frame update
    void Start()
    {
        pipeMove = currentPipe.GetComponent<PipeMoveScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            pipeMove.openPipe();
        }
    }
}
