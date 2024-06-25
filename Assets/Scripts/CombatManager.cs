using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public IslandManager islandManager;
    public int maxCombatTurns = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // DoCombatChecks(); //TODO remove this when turns exist
    }

    public void DoCombatChecks()
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

        for (combatTurn = 0; combatTurn < maxCombatTurns; combatTurn++)
        {
            DoCombatLoop(cohortUnits, enemies);
        }
    }
    void DoCombatLoop(List<CohortUnit> cohortUnits, List<Enemy> enemies)
    {
        if (cohortUnits.Count == 0 || enemies.Count == 0)
        {
            if (enemies.Count == 0)
            {
                foreach (CohortUnit unit in cohortUnits)
                {
                    unit.attack++;
                }
            }
            return;
        }
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
