using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardThruster : MonoBehaviour
{
    [SerializeField]
    private float targetSpeed;
    [SerializeField]
    private float relativeForce;
    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float fuelConsumptionPerNewton;

    Rigidbody2D body;
    FuelTank tank;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        tank = GetComponent<FuelTank>();
    }

    private void FixedUpdate()
    {
        var speed = body.velocity.x;
        var force = Mathf.Min(relativeForce * (targetSpeed - speed), maxForce);

        var delta = Time.fixedDeltaTime;

        if (!tank.IsEmpty())
        {
            body.AddForce(new Vector2(force * delta, 0.0f));
            tank.Burn(fuelConsumptionPerNewton * force * delta);
        }
    }
}
