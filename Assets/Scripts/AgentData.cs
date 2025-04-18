using UnityEngine;

public class AgentData : MonoBehaviour
{
    [Header("Needs Decay Rates (units per game time unit)")]
    public float energyDecayRate = 0.5f;
    public float hungerDecayRate = 0.8f;
    public float stressGainRate = 0.2f;  
    public float stressRecoveryRate = 0.4f; 

    [Header("TEMP STATE FOR TESTING")]
    public bool TEMP_isIdle = false;

    [Header("Needs")]
    public float energy = 100f;
    public float hunger = 100f;
    public float stress = 0f;
    public float safety = 100f;

    [Header("Traits")]
    public float moveSpeed = 3f;
    public float workSpeed = 1f;
    public float lifespan = 100f;

    [Header("State & Identity")]
    public string agentName = "Agent";
    public string sex = "Female";
    public float age = 0f;
    public bool isPregnant = false;
    public float pregnancyTimer = 0f;
    public float reproductionCooldownTimer = 0f;
    private float gameTimeAgeFactor = 1.0f;

    void Update()
    {
        if (Time.timeScale > 0)
        {
            float timePassed = Time.deltaTime * Time.timeScale * gameTimeAgeFactor;

            energy -= energyDecayRate * timePassed;
            hunger -= hungerDecayRate * timePassed;

            energy = Mathf.Max(0f, energy);
            hunger = Mathf.Max(0f, hunger);

            if (TEMP_isIdle)
            {
                stress -= stressRecoveryRate * timePassed;
            }
            else 
            {
                stress += stressGainRate * timePassed;
            }
            stress = Mathf.Clamp(stress, 0f, 100f);

            age += timePassed; 
            if (age >= lifespan)
            {
                Die();
                return; 
            }
        } 
    }

    public void Die()
    {
        if (!gameObject.activeSelf) return;

        Debug.Log($"{agentName} (Age: {age:F1}) has died of old age (Lifespan: {lifespan}).");
        Destroy(gameObject);
    }
}