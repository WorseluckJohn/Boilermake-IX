using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorScript : MonoBehaviour
{
    public int count = 0;
    public float times;
    public Vector3 startPos;
    public bool toggle = true;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        InvokeRepeating("moveTractor", 0, times);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, 0, speed * Time.deltaTime);

    }

    void moveTractor()
    {
        count++;
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSecondsRealtime(times);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name != "Tracker")
        {
            if (toggle)
            {
                other.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                other.gameObject.transform.localScale = new Vector3(1, .25f, 1);
            }
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 5f, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.RotateAround(transform.position, transform.up, 180f);
        }
    }
}    