using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TouchControlScript : MonoBehaviour
{
    private Touch touch;
    private Vector3 pos;
    private float speedModifier;
    [SerializeField]

    private Vector3 Position;
    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 0.011f;
        pos.x = PlayerPrefs.GetFloat("PosX");
        pos.y = PlayerPrefs.GetFloat("PosY");
        pos.z = 0;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {

        Position = transform.position;


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {

                Position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y + touch.deltaPosition.y * speedModifier, Position.z);
                Position.x = Mathf.Clamp(Position.x, -21.45f, 21.45f);
                Position.y = Mathf.Clamp(Position.y, -11.25f, 11.25f);
                transform.position = Position;

            }

        }

    }

    public void OnSave()
    {
        setPositionValue(Position);
    }
    private void setPositionValue(Vector3 pos)
    {
        PlayerPrefs.SetFloat("PosX", pos.x);
        PlayerPrefs.SetFloat("PosY", pos.y);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
