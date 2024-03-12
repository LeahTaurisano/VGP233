using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float cameraDistance;
    [SerializeField] private float cameraHeight;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float maxHeightOffset;
    [SerializeField] private bool invertCamera;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.position = new Vector3(transform.position.x, transform.position.y + cameraHeight, transform.position.z);
    }

    private void LateUpdate()
    {
        float vertical;
        if (Input.GetMouseButton(1))
        {
            vertical = Input.GetAxis("Mouse Y") * verticalSpeed;
            if (invertCamera)
            {
                vertical *= -1;
            }
        }
        else
        {
            vertical = 0;
        }
        float yPos = transform.position.y + vertical;
        float maxHeight = player.transform.position.y + maxHeightOffset;
        float minHeight = player.transform.position.y;
        if (yPos > maxHeight)
        {
            yPos = maxHeight;
        }
        else if (yPos < minHeight)
        {
            yPos = minHeight;
        }

        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        transform.LookAt(player.transform.position);
    }
}