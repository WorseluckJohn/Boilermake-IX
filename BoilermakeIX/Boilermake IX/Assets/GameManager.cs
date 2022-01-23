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

        if (tractorScript.count == 7)
        {
            
        }
    }

    void resetPlanter()
    {
        tractor.transform.position = tractorScript.startPos;
        tractor.transform.RotateAround(tractor.transform.position, tractor.transform.up, 180f);
        tractorScript.toggle = !tractorScript.toggle;
    }
}
