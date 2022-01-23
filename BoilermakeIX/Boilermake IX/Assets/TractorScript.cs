using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorScript : MonoBehaviour
{
    public int count = 0;
    public float times;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("moveTractor", 0, times);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, 0, 3 * Time.deltaTime);

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
        
        if(toggle)
        {
            gameObject.transform.RotateAround(transform.position, transform.up, 180f);
        }
        else
        {
            gameObject.transform.RotateAround(transform.position, transform.up, 180f);
        }
        toggle = !toggle;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}    