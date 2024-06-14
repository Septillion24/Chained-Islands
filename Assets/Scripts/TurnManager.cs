using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public CohortManager cohortManager;
    public IslandManager islandManager;
    public int maxCombatTurns = 20;

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
        DoCombatChecks();
        cohortManager.RefreshMovement();
    }


    void DoCombatChecks()
    {
        List<Island> contestedIsladns = GetContestedIslands();
        if (contestedIsladns.Count > 0)
        {
            foreach (Island island in contestedIsladns)
            {
                DoCombat(island);
            }
        }
    }

    void DoCombat(Island island)
    {
        int combatTurn = 0;
        List<CohortUnit> cohortUnits = island.cohortUnitsStationedHere;
        List<Enemy> enemies = island.enemiesStationedHere;

        for (int i = 0; i < maxCombatTurns; i++)
        {
            DoCombatLoop(cohortUnits, enemies);
        }
    }
    void DoCombatLoop(List<CohortUnit> cohortUnits, List<Enemy> enemies)
    {

        int cohortAttackScore = 0;
        foreach (CohortUnit unit in cohortUnits)
        {
            cohortAttackScore += unit.DoAttackRoll();
        }
        int enemyAttackScore = 0;
        foreach (Enemy enemy in enemies)
        {
            enemyAttackScore += enemy.DoAttackRoll();
        }

        int attackBalance = cohortAttackScore - enemyAttackScore;

        if (attackBalance < 0)
        {
            foreach (CohortUnit unit in cohortUnits)
            {
                unit.TakeDamage(-attackBalance);
                unit.UpdateHealthBar();
            }
        }
        else if (attackBalance > 0)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.TakeDamage(attackBalance);
                enemy.UpdateHealthBar();
            }
        }

    }
    public List<Island> GetContestedIslands()
    {
        List<Island> contestedIslands = new List<Island>();
        foreach (Island island in islandManager.islands)
        {
            if (island.cohortUnitsStationedHere.Count > 0 && island.enemiesStationedHere.Count > 0)
            {
                contestedIslands.Add(island);
            }
        }
        return contestedIslands;
    }

}


