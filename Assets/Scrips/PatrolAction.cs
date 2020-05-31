using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act (StateController controller)
    {

    }

    private void Patrol (StateController controller)
    {
        //controller.transform.position = Vector2.MoveTowards(controller.transform.position, controller.currentPatrol.transform.position, moveSpeed * Time.deltaTime);
        /* if (Vector2.Distance(transform.position, currentPatrol.transform.position) < 0.2f)
         {
             if (currentPatrol == PatrolPoint2)
             {
                 currentPatrol = PatrolPoint1;
             }
             else if (currentPatrol == PatrolPoint1)
             {
                 currentPatrol = PatrolPoint2;
             }
         }*/
    }
}
