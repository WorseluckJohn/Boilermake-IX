using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterScript : MonoBehaviour
{
    public float times;
    public int count;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.activeSelf == true)
        {
            InvokeRepeating("moveTractor", 0, times);
        }

    }

    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    void moveTractor()
    {
        count++;
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        bool toggle = true;
        yield return new WaitForSecondsRealtime(times);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z);

        if (toggle)
        {
            gameObject.transform.RotateAround(transform.position, transform.up, 180f);
        }
        else
        {
            gameObject.transform.RotateAround(transform.position, transform.up, 180f);
        }
        toggle = !toggle;
    }
}