using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InPortalTrigger : MonoBehaviour
{
    public bool triggered = false;
    public GameObject pinball;

    private void Update()
    {
        if (!BallManager.IsBallActive())
        {
            triggered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pinball")
        {
            pinball = collision.gameObject;
            triggered = true;
        }
    }
}
