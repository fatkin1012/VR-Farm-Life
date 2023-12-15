using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject fishingRodPrefab;
    public GameObject canvasPrefab;

    private CharacterController characterController;
    private bool onPlane = false;

    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        float distanceToGround = 1f;

        if (Physics.Raycast(player.transform.position, -Vector3.up, out RaycastHit hit, distanceToGround + 1f))
        {
            if (hit.collider.gameObject.CompareTag("Plane"))
            {
                if (!onPlane)
                {
                    onPlane = true;
                    StartCoroutine(SpawnCanvasAndFishingRod());
                }
            }
            else
            {
                onPlane = false;
            }
        }
    }

    private void OnTriggerEnter(Collider Player)
    {
        //StartCoroutine(SpawnCanvasAndFishingRod());
        canvasPrefab.SetActive(true);
        fishingRodPrefab.SetActive(true);
    }
    private void OnTriggerExit(Collider Player)
    {
        //StartCoroutine(SpawnCanvasAndFishingRod());
        canvasPrefab.SetActive(false);
        fishingRodPrefab.SetActive(false);
    }
    IEnumerator SpawnCanvasAndFishingRod()
    {
        yield return new WaitForSeconds(0.1f);

        GameObject fishingRod = Instantiate(fishingRodPrefab, player.transform.position, player.transform.rotation);
        fishingRod.transform.SetParent(player.transform);
        fishingRod.transform.localPosition = new Vector3(-0.5f, 0.2f, 0.2f);

        GameObject canvas = Instantiate(canvasPrefab, player.transform.position, player.transform.rotation);
        canvas.transform.SetParent(player.transform);
        canvas.transform.localPosition = new Vector3(0, 0.2f, 1);
    }
}