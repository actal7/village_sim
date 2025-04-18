using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 1f;
            Debug.Log("Time Scale: 1x");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 5f;
            Debug.Log("Time Scale: 5x");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 10f;
            Debug.Log("Time Scale: 10x");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Time.timeScale = 0f;
            Debug.Log("Time Scale: Paused (0x)");
        }
         else if (Input.GetKeyDown(KeyCode.Space))
        {
             if (Time.timeScale > 0f)
             {
                 Time.timeScale = 0f;
                 Debug.Log("Time Scale: Paused (0x)");
             }
             else
             {
                 Time.timeScale = 1f;
                 Debug.Log("Time Scale: 1x");
             }
        }
    }

    
    public void SetTimeScale(float scale)
    {
        Time.timeScale = Mathf.Max(0f, scale); 
        Debug.Log("Time Scale set to: " + Time.timeScale);
    }
}