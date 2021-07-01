using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSprite : MonoBehaviour
{

    //public GameObject mySound;
    private Vector2 screenBounds;
    private float objectWidth, objectHeight, movementSpeed;
    private Vector3 target;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<Renderer>().bounds.extents.x;
        objectHeight = GetComponent<Renderer>().bounds.extents.y;
        target = Random.onUnitSphere * 1000;
        target.z = 0;
        movementSpeed = 1f;
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        Debug.Log(screenBounds);
        Debug.Log(objectWidth);
        GetComponent<AudioSource>().Stop();
    }


    private void move()
    {
        Vector3 pos = transform.position;

        ////check to see if still withing camera and if not changes position
        pos.x = Mathf.Clamp(pos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        pos.y = Mathf.Clamp(pos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = pos;
        if (pos.x <= (screenBounds.x * -1 + objectWidth) | (pos.x >= screenBounds.x - objectWidth))
        {

            target.x = -target.x;
            //target.y = Random.Range(-10000, 10000);

        }
        if (pos.y <= (screenBounds.y * -1 + objectHeight) | (pos.y >= screenBounds.y - objectHeight))
        {

            target.y = -target.y;
            //target.x = Random.Range(-10000, 10000);

        }

        // moving the button
        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);

    }

    //private void sound()
    //{
    //    mySound.SetActive(true);
    //}

    void Update()
    {
        move();
    }
}
