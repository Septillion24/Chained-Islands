using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public IslandManager islandManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // DoCombatChecks(); //TODO remove this when turns exist
    }

    void DoCombatChecks()
    {
        foreach (Island island in islandManager.islands)
        {
            if (island.cohortUnitsStationedHere.Count > 1 && island.enemiesStationedHere.Count > 0)
            {
                DoCombat(island);
            }
        }
    }

    void DoCombat(Island island)
    {
        print("Combat!!!");
    }
}
