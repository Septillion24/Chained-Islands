using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohortUnit : MonoBehaviour
{


    public Island currentLocation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(Island islandToGoTo)
    {
        currentLocation = islandToGoTo;
        transform.position = islandToGoTo.transform.position;
    }

}
