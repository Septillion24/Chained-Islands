using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IslandManager : MonoBehaviour
{

    public List<Island> islands = new List<Island>();
    public GameObject islandChain;



    // Start is called before the first frame update
    void Start()
    {
        islands = GetComponentsInChildren<Island>().ToList();

        foreach (Island island in islands)
        {
            island.islandID = island.GetInstanceID();
            foreach (Island adjacentIsland in island.adjacentIslands)
            {
                Transform start = island.transform;
                Transform end = adjacentIsland.transform;
                print("Start" + start.position + ", End: " + end.position);

                GameObject chain = Instantiate(islandChain, island.transform.position, Quaternion.identity);
                LineRenderer lineRenderer = chain.GetComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, start.position);
                lineRenderer.SetPosition(1, end.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
