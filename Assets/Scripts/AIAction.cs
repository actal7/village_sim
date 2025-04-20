using UnityEngine;

[CreateAssetMenu(fileName = "New AI Action", menuName = "AI/AI Action")]
public abstract class AIAction : ScriptableObject
{
    public string actionName = "Default Action";
    public abstract float CalculateScore(AgentData agentData, AgentController controller); 
    public virtual void OnStartExecute(AgentData agentData, AgentController controller) { }
    public abstract void Execute(AgentData agentData, AgentController controller);
    public virtual void OnStopExecute(AgentData agentData, AgentController controller) { }
}