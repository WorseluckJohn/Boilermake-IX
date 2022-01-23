using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cam1st;
    public Camera cam3rd;
    public TractorScript tractorScript;
    public GameObject planter;
    public GameObject tractor;
    public GameObject rain;
    public GameObject plants;

    // Start is called before the first frame update
    void Start()
    {
        
        tractor = GameObject.Find("tractor");
        tractorScript = GameObject.Find("tractor").GetComponent<TractorScript>();
        cam1st.enabled = false;
        cam3rd.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        startPlanter();
    }

    public void changeCamera()
    {
        cam1st.enabled = !cam1st.enabled;
        cam3rd.enabled = !cam3rd.enabled;
    }

    void startPlanter()
    {
        if(tractorScript.count == 3)
        {
            //planter.SetActive(true);
            //cam1st.transform.parent = planter.transform;
            resetPlanter();
            tractorScript.count++;

        }

        if (tractorScript.count == 6)
        {
            StartCoroutine(Timer());
            tractorScript.count++;
        }
    }
    IEnumerator Timer()
    {
        yield return new 
        WaitForSecondsRealtime(3);
        rain.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        rain.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        foreach(Transform plant in plants.transform)
        {
            plant.gameObject.transform.localScale = new Vector3(1, Random.Range(.75f, 2), 1);
        }
        resetPlanter();
    }

    void resetPlanter()
    {
        tractor.transform.position = tractorScript.startPos;
        tractor.transform.RotateAround(tractor.transform.position, tractor.transform.up, 180f);
        tractorScript.toggle = !tractorScript.toggle;
    }
}
