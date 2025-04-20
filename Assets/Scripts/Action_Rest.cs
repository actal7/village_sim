using UnityEngine;

[CreateAssetMenu(fileName = "Rest Action", menuName = "AI/Actions/Rest Action")]
public class Action_Rest : AIAction
{
    [Header("Execution")]
    public float energyRecoveryRate = 5.0f;
    public float stressRecoveryRateMultiplier = 1.5f;
    public override float CalculateScore(AgentData agentData, AgentController controller)
    {
        float energyScore = Mathf.InverseLerp(100f, 0f, agentData.energy);
        return energyScore;
    }

    public override void OnStartExecute(AgentData agentData, AgentController controller) {
        controller.GetAgentMovement()?.StopMoving();
        agentData.TEMP_isIdle = true;
        Debug.Log($"{agentData.name} started Resting (Energy: {agentData.energy:F1}).");
    }

    public override void Execute(AgentData agentData, AgentController controller) {
        float timePassed = Time.deltaTime * Time.timeScale;
        agentData.energy += energyRecoveryRate * timePassed;
        agentData.energy = Mathf.Min(100f, agentData.energy);

        if (!agentData.TEMP_isIdle) {
            agentData.TEMP_isIdle = true;
        }

        agentData.stress -= agentData.stressRecoveryRate * stressRecoveryRateMultiplier * timePassed;
        agentData.stress = Mathf.Max(0f, agentData.stress);
    }

    public override void OnStopExecute(AgentData agentData, AgentController controller) {
        agentData.TEMP_isIdle = false;
        Debug.Log($"{agentData.name} stopped Resting (Energy: {agentData.energy:F1}).");
    }
}