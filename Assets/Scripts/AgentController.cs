using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(AgentData))]
[RequireComponent(typeof(AgentMovement))]
public class AgentController : MonoBehaviour
{
    public List<AIAction> availableActions;

    private AgentData agentData;
    private AgentMovement agentMovement;

    private AIAction currentAction;

    void Awake()
    {
        agentData = GetComponent<AgentData>();
        agentMovement = GetComponent<AgentMovement>();
    }

    void Update()
    {
        if (Time.timeScale <= 0 || !gameObject.activeSelf) return;
        ChooseAction();
        ExecuteCurrentAction();
    }

    void ChooseAction()
    {
        if (availableActions == null || availableActions.Count == 0)
        {
             if (currentAction != null) {
                 currentAction.OnStopExecute(agentData, this);
                 currentAction = null;
             }
             return;
        }

        float bestScore = -Mathf.Infinity;
        AIAction bestAction = null;

        foreach (AIAction action in availableActions)
        {
            float score = action.CalculateScore(agentData, this);

            if (score > bestScore)
            {
                bestScore = score;
                bestAction = action;
            }
        }

        if (bestAction != null && bestAction != currentAction)
        {
            if (currentAction != null)
            {
                currentAction.OnStopExecute(agentData, this);
            }
            currentAction = bestAction;
            currentAction.OnStartExecute(agentData, this);
            Debug.Log($"Agent {gameObject.name} started action: {currentAction.actionName}");
        }

        else if (bestAction == null && currentAction != null)
        {
             currentAction.OnStopExecute(agentData, this);
             currentAction = null;
             Debug.Log($"Agent {gameObject.name} stopped actions, no suitable action found.");
        }
    }

    void ExecuteCurrentAction()
    {
        if (currentAction != null)
        {
            currentAction.Execute(agentData, this);
        }
        else
        {
            Debug.LogError($"Agent {gameObject.name} has no current action! Possible configuration error (Missing Idle Action?).");
        }
    }

    public AgentData GetAgentData() => agentData;
    public AgentMovement GetAgentMovement() => agentMovement;
}