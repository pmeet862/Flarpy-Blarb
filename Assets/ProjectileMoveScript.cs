using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;
    private float moveSpeed;

    private string TARGET_TAG = "Target";


    // Update is called once per frame
    void Update()
    {
        if (LogicScript.isPaused == true)
        {
            moveSpeed = 0f;
        }
        else
        {
            moveSpeed = projectileSpeed;
        }
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.CompareTag(TARGET_TAG))
            Destroy(gameObject);
    }
}
