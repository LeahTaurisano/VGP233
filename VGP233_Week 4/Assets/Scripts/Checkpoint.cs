using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 respawnPosition;

    private void Start()
    {
        respawnPosition = transform.position;
    }

    public Vector3 GetRespawnPosition()
    {
        return respawnPosition;
    }
}
