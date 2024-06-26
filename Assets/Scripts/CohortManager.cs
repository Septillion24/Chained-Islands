using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class CohortManager : MonoBehaviour
{

    public IslandManager islandManager;

    public List<CohortUnit> cohortMemberPrefabs = new List<CohortUnit>();
    public List<CohortUnit> cohortUnits = new List<CohortUnit>();





    // Start is called before the first frame update
    void Start()
    {
        // TODO: do this when moving normally
        foreach (CohortUnit cohortMemberPrefab in cohortMemberPrefabs)
        {
            print("A");
            CohortUnit cohortUnit = Instantiate(cohortMemberPrefab, transform.position, Quaternion.identity, transform);
            cohortUnits.Add(cohortUnit);

            cohortUnit.currentLocation = islandManager.startIsland;
            islandManager.startIsland.cohortUnitsStationedHere.Add(cohortUnit);
        }
        SetCohortPositions();






    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetCohortPositions()
    {
        Dictionary<Island, List<CohortUnit>> allCohortPositions = new Dictionary<Island, List<CohortUnit>>();
        foreach (CohortUnit unit in cohortUnits)
        {
            Island unitPosition = unit.currentLocation;
            if (allCohortPositions.Keys.Contains(unitPosition))
            {
                allCohortPositions[unitPosition].Add(unit);
            }
            else
            {
                allCohortPositions[unitPosition] = new List<CohortUnit> { unit };
            }
        }
        foreach (Island island in allCohortPositions.Keys)
        {
            Vector3[] islandCohortPositions = island.getCohortPositions();
            List<CohortUnit> unitsOnIsland = allCohortPositions[island];
            for (int i = 0; i < unitsOnIsland.Count; i++)
            {
                unitsOnIsland[i].transform.position = islandCohortPositions[i];
            }
        }
    }


    public bool TryMoveUnit(CohortUnit unit, Island islandToGoTo)
    {
        Island currentIsland = unit.currentLocation;
        if (unit.movement < 1)
        {
            return false;
        }
        if (islandManager.CheckAdjacent(currentIsland, islandToGoTo))
        {

            currentIsland.cohortUnitsStationedHere.Remove(unit);
            islandToGoTo.cohortUnitsStationedHere.Add(unit);
            unit.MoveTo(islandToGoTo);
            unit.ReduceMovement(1);

            SetCohortPositions();
            return true;
        }
        return false;
    }
    public bool TryMoveUnit(CohortUnit unit, Island islandToGoTo, bool force)
    {
        if (force)
        {
            return TryMoveUnit(unit, islandToGoTo);
        }
        return false;
    }

    public void RefreshMovement()
    {
        foreach (CohortUnit unit in cohortUnits)
        {
            unit.RefreshMovement();
        }
    }



}
