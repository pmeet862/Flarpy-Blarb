using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private float flapStrength;
    private LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicScript.isPaused == true)
        {
            myRigidbody.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
        //For sending bird upwards spacebae press
        if (Input.GetKeyDown(KeyCode.Space) == true || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            int i = 0;
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.GetTouch(i).position;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            if (results.Count > 0 && results[0].gameObject.name == "Shoot BTN")
            {

                return;
            }

            if (birdIsAlive == true && LogicScript.isPaused == false)
                myRigidbody.velocity = Vector2.up * flapStrength;

        }

        //For gameover when bird went off the screen
        if (transform.position.y > 13 || transform.position.y < -14)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    //For gameover when bird collide with other object 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}
