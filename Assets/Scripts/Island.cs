using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Island : MonoBehaviour
{
    public Sprite islandSprite;
    public Island[] adjacentIslands;
    public int islandID;
    public int islandType;

    public float maxWidth = 3.0f;
    public float portraitHeight = 1.0f;

    public List<CohortUnit> cohortUnitsStationedHere;


    // Start is called before the first frame update
    void Start()
    {

    }



    void OnValidate()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = islandSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public Vector3[] getCohortPositions()
    {
        Vector3 centerPoint = transform.position;
        int count = cohortUnitsStationedHere.Count;
        Vector3[] positions = new Vector3[count];

        if (count == 1)
        {
            positions[0] = centerPoint;
        }
        else
        {
            float totalWidth = maxWidth;
            float spacing = totalWidth / (count - 1);
            float startX = centerPoint.x - totalWidth / 2;

            for (int i = 0; i < count; i++)
            {
                float currentX = startX + i * spacing;
                positions[i] = new Vector3(currentX, centerPoint.y+portraitHeight, centerPoint.z);
            }
        }
        return positions;
    }



}
