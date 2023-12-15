using UnityEngine;

public class PlaneSensor : MonoBehaviour
{
    private FishingEvent spawnManager;
    private bool isPlayerStandingOnPlane;

    void Start()
    {
        spawnManager = FindObjectOfType<FishingEvent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerStandingOnPlane = true;
            spawnManager.ShowPressFKeyMessage();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerStandingOnPlane = false;
            spawnManager.HidePressFKeyMessage();
        }
    }

    public bool IsPlayerStandingOnPlane()
    {
        return isPlayerStandingOnPlane;
    }
}