using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CohortManager : MonoBehaviour
{

    public IslandManager islandManager;

    public List<CohortUnit> cohortMemberPrefabs = new List<CohortUnit>();
    List<CohortUnit> cohortUnits = new List<CohortUnit>();





    // Start is called before the first frame update
    void Start()
    {
        foreach (CohortUnit cohortMemberPrefab in cohortMemberPrefabs)
        {
            CohortUnit cohortUnit = Instantiate(cohortMemberPrefab, transform.position, Quaternion.identity, transform);
            cohortUnits.Add(cohortUnit);

            cohortUnit.currentLocation = islandManager.startIsland;
            islandManager.startIsland.cohortUnitsStationedHere.Add(cohortUnit);
        }

        Vector3[] cohortPositions = islandManager.startIsland.getCohortPositions();
        for (int i = 0; i < cohortPositions.Length; i++)
        {
            cohortUnits[i].transform.position = cohortPositions[i];
        }





    }

    // Update is called once per frame
    void Update()
    {

    }
}
