using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AISight : MonoBehaviour
{
    [SerializeField] private EnemyMovement aiMove;
    [SerializeField] private Material lightYellow;
    [SerializeField] private Material lightRed;

    private MeshRenderer lightMesh;
    private float seenTimerMax = 5.0f;
    private float seenTimer = 0.0f;

    private void Start()
    {
        lightMesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaycastHit hit;
            if (Physics.Linecast(aiMove.transform.position, other.transform.position, out hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    aiMove.FoundPlayer(other.transform);
                    lightMesh.material = lightRed;
                    seenTimer += Time.deltaTime;
                    if (seenTimer > seenTimerMax)
                    {
                        GameManager.Instance.GameOver();
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightMesh.material = lightYellow;
            seenTimer = 0.0f;
        }
    }
}