using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public CohortManager cohortManager;
    public IslandManager islandManager;
    public CombatManager combatManager;
    public int maxCombatTurns = 20;

    public bool wonGame = false;
    public GameObject winScreen;

    int currentTurn = 0;


    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void NextTurn()
    {
        currentTurn++;
        combatManager.DoCombatChecks();
        cohortManager.RefreshMovement();
        foreach (CohortUnit unit in cohortManager.cohortUnits)
        {
            if (unit.currentLocation == islandManager.endIsland)
            {
                winScreen.SetActive(true);
            }
        }
    }




}


