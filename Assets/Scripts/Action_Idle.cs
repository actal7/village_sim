using UnityEngine;

[CreateAssetMenu(fileName = "Idle Action", menuName = "AI/Actions/Idle Action")]
public class Action_Idle : AIAction
{
    public float constantScore = 0.01f;

    public override float CalculateScore(AgentData agentData, AgentController controller)
    {
        return constantScore;
    }

    public override void OnStartExecute(AgentData agentData, AgentController controller) {
        controller.GetAgentMovement()?.StopMoving();

        agentData.TEMP_isIdle = true;
        Debug.Log($"{agentData.name} started Idling."); 
    }

    public override void Execute(AgentData agentData, AgentController controller) {
        if (!agentData.TEMP_isIdle) {
            agentData.TEMP_isIdle = true;
        }
    }

    public override void OnStopExecute(AgentData agentData, AgentController controller) {
        agentData.TEMP_isIdle = false;
        Debug.Log($"{agentData.name} stopped Idling.");
    }
}