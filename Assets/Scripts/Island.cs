using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Island : MonoBehaviour, ISelectable
{
    public Sprite islandSprite;
    public Island[] adjacentIslands;
    public int islandID;
    public int islandType;

    public float maxWidth = 3.0f;
    public float portraitHeight = 1.0f;
    public float portraitOffset = -1.0f;
    public bool useMaxWidth = false;

    public List<CohortUnit> cohortUnitsStationedHere;
    public List<Enemy> enemiesStationedHere;

    public bool isSelected { get => isSelected; set => isSelected = value; }


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
        if (useMaxWidth)
        {
            return getCohortPositionsEven();
        }
        else
        {
            return getCohortPositionsOdd();
        }
    }
    private Vector3[] getCohortPositionsOdd()
    {
        Vector3 centerPoint = transform.position;
        int count = cohortUnitsStationedHere.Count;
        Vector3[] positions = new Vector3[count];

        if (count == 1)
        {
            float startX = centerPoint.x - maxWidth / 2;
            positions[0] = new Vector3(startX + portraitOffset, centerPoint.y + portraitHeight, centerPoint.z);
        }
        else
        {
            float totalWidth = maxWidth;
            float spacing = totalWidth / 3;
            float startX = centerPoint.x - totalWidth / 2;

            for (int i = 0; i < count; i++)
            {
                float currentX = startX + i * spacing;
                positions[i] = new Vector3(currentX + portraitOffset, centerPoint.y + portraitHeight, centerPoint.z);
            }
        }
        return positions;
    }
    private Vector3[] getCohortPositionsEven()
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
                positions[i] = new Vector3(currentX + portraitOffset, centerPoint.y + portraitHeight, centerPoint.z);
            }
        }
        return positions;
    }

    public void OnSelect()
    {
        isSelected = true;
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        if (renderer != null && SelectableMaterials.selectedMaterial != null)
        {
            renderer.material = SelectableMaterials.selectedMaterial;
        }
    }

    public void OnDeselect()
    {
        isSelected = false;
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.material = SelectableMaterials.defaultMaterial;
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
