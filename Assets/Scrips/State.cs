﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/State")]
public class State : ScriptableObject
{
    public Action[] actions;

    public void UpdateState (StateController controller)
    {
        DoActions(controller);
    }

    private void DoActions (StateController controller)
    {
        foreach (Action act in actions)
        {
            act.Act(controller);
        }
    }
}
