using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutCreate : MonoBehaviour
{
    private GameObject layout;
    public GameObject plantPrefab;
    public int xlimit = 10;
    public int zlimit = 10;

    // Start is called before the first frame update
    void Start()
    {
        layout = gameObject;
        plantPrefab = gameObject.transform.GetChild(0).gameObject;

        createPlants();
        spreadLayout();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createPlants()
    {
        for (int i = 0; i < xlimit * zlimit; i++)
        {
            var newPlant = Instantiate(plantPrefab);
            newPlant.transform.parent = gameObject.transform;
        }

    }

    void spreadLayout()
    {
        int count = 0;

        for (int i = 0; i < xlimit; i++)
        {
            for(int j = 0; j < zlimit; j++)
            {
                layout.transform.GetChild(count).gameObject.transform.position
                 = new Vector3((layout.transform.GetChild(count).gameObject.transform.position.x + i),
                 layout.transform.GetChild(count).gameObject.transform.position.y, layout.transform.GetChild(count).gameObject.transform.position.z + j);
                count = count + 1; 
            }
        }
    }    
}
