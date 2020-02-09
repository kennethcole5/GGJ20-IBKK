using UnityEngine;

class BasicIdleState : State
{
    [SerializeField] private float idleFor = 1f;
    private float stateStartTime = 0f;
    private bool resetEnterTime = true;

    public override void EnterState(StateMachine parent)
    {
        resetEnterTime = true;
    }

    public override void UpdateState(StateMachine parent)
    {
        if (resetEnterTime)
        {
            stateStartTime = Time.time;
            resetEnterTime = false;
            Unit unit = GetComponent<Unit>();
            if (unit != null)
            {
                unit.anim.SetTrigger("Attack");
            }
        }
        
        if (Time.time < stateStartTime + idleFor) return;
        InitiativeSystem.nextTurn();
        parent.PopState();
    }
}