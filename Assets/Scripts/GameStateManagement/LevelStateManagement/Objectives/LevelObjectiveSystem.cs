﻿using System.Collections.Generic;
using UnityEngine;

public class LevelObjectiveSystem : MonoBehaviour
{
    #region Singleton
    public static LevelObjectiveSystem Instance;
    private void OnEnable() => Instance = this;
    #endregion

    /* Variables */

    [Header("Properties")]
    [SerializeField] private List<LevelObjective> mandatoryObjectives = new List<LevelObjective>();
    [SerializeField] private string levelToLoadAfterThisOne = "Level 2";

    // States
    private bool highlightedExit = false;

    /* Main Functionality */

    //Called by an objective
    public void ObjectiveCompleted()
    {
        if (highlightedExit == false && AllMandatoryObjectivesCompleted())
            CompletedLastMandatoryObjective();
    }

    /* Helper Functions */

    private void CompletedLastMandatoryObjective()
    {
        highlightedExit = true;

        UiManager.Instance.LevelCompleted();
    }

    private bool AllMandatoryObjectivesCompleted()
    {
        foreach (LevelObjective mandatoryObjective in mandatoryObjectives)
        {
            if (mandatoryObjective.Completed == false)
                return false;
        }

        return true;
    }
}
