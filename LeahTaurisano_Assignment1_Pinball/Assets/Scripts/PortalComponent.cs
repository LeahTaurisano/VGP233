using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalComponent : MonoBehaviour
{
    [SerializeField] private GameObject outPortal;
    [SerializeField] private SpriteRenderer inPortalSprite;
    [SerializeField] private SpriteRenderer outPortalSprite;
    [SerializeField] private InPortalTrigger inPortalTrigger;
    [SerializeField] private float portalDelay;

    private bool inWaiting = false;
    private float timer = 0.0f;
    private float outPortalDelay = 0.5f;
    private GameObject pinball;
    private Rigidbody2D pinballRigidBody;
    private SpriteRenderer pinballSprite;
    private Vector2 pinballVelocity;
    private float xVelocity;
    private float yVelocity;
    private int yVariance;

    private void Start()
    {
        inPortalSprite.enabled = true;
        outPortalSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inPortalTrigger.triggered)
        {
            if (!inWaiting)
            {
                pinball = inPortalTrigger.pinball;
                pinballRigidBody = pinball.GetComponent<Rigidbody2D>();
                pinballSprite = pinball.GetComponent<SpriteRenderer>();
                pinballVelocity = pinballRigidBody.velocity;
                inPortalSprite.enabled = false;
                pinballSprite.enabled = false;
                inWaiting = true;
            }
            timer += Time.deltaTime;

            if (timer >= portalDelay)
            {
                LaunchBall(pinball, pinballVelocity, pinballRigidBody);
                pinballSprite.enabled = true;
                timer = 0.0f;
                inWaiting = false;
                inPortalTrigger.triggered = false;
            }
        }
        if (outPortalSprite.enabled)
        {
            timer += Time.deltaTime;
            if (timer >= outPortalDelay)
            {
                outPortalSprite.enabled = false;
                inPortalSprite.enabled = true;
                timer = 0.0f;
            }
        }
    }

    public void LaunchBall(GameObject pinball, Vector2 pinballVelocity, Rigidbody2D pinballBody)
    {
        outPortalSprite.enabled = true;
        pinball.transform.position = outPortal.transform.position;
        xVelocity = Random.Range(pinballVelocity.y, -pinballVelocity.y);
        yVariance = Random.Range(0, 2);
        if (yVariance == 0)
        {
            yVelocity = pinballVelocity.y - xVelocity;
        }
        else
        {
            yVelocity = (pinballVelocity.y - xVelocity) * -1;
        }
        
        pinballBody.velocity = new Vector2(xVelocity, yVelocity);
    }
}
