using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIPath))]
public class AgentMovement : MonoBehaviour
{
    private AIPath aiPath;

    void Awake()
    {
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            Debug.LogError("AIPath component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (aiPath != null)
                {
                    MoveTo(hit.point);
                    Debug.Log("New destination set to: " + hit.point);
                }
            }
        }
    }

    public void StopMoving()
    {
        if (aiPath != null)
        {
            aiPath.isStopped = true;
        }
    }

    public void MoveTo(Vector3 destination)
    {
        if (aiPath != null)
        {
            aiPath.isStopped = false;
            aiPath.destination = destination;
        }
    }
}