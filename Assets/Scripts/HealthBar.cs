using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Unit unit;
    public GameObject healthBarPip;
    // public float maxWidth = 1.0f;
    public float spacing = 0.051f;


    void Awake()
    {
        foreach (Vector3 position in GetHealthBarPipLocations())
        {
            GameObject pip = Instantiate(healthBarPip, position, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3[] GetHealthBarPipLocations()
    {
        Vector3 centerPoint = transform.position;
        int count = unit.maxHealth;
        Vector3[] positions = new Vector3[count];

        if (count == 1)
        {
            positions[0] = centerPoint;
        }
        else
        {

            // float totalWidth = maxWidth;
            // float spacing = totalWidth / (count - 1);
            float startX = centerPoint.x - (spacing * (count - 1) / 2);

            for (int i = 0; i < count; i++)
            {
                float currentX = startX + i * spacing;
                positions[i] = new Vector3(currentX, centerPoint.y, centerPoint.z);
            }
        }
        return positions;
    }
}
