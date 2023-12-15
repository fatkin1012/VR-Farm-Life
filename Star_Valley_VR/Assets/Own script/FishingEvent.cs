using UnityEngine;

public class FishingEvent : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float distanceFromPlayer = 5f;

    void Start()
    {
        // Example usage
        SpawnObjectInFrontOfPlayer(objectToSpawn, distanceFromPlayer);
    }

    public GameObject SpawnObjectInFrontOfPlayer(GameObject objectToSpawn, float distanceFromPlayer)
    {
        if (objectToSpawn == null || FindObjectOfType(objectToSpawn.GetType()) != null)
        {
            return null;
        }

        Vector3 spawnPosition = GetPlayer().transform.position + GetPlayer().transform.forward * distanceFromPlayer;
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        return spawnedObject;
    }

    private GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("LeftHand");
    }

    public GameObject pressFKeyUI;


    public void ShowPressFKeyMessage()
    {
        pressFKeyUI.SetActive(true);
    }

    public void HidePressFKeyMessage()
    {
        pressFKeyUI.SetActive(false);
    }
}