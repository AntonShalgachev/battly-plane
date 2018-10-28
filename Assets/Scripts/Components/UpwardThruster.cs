using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardThruster : MonoBehaviour
{
    [SerializeField]
    private float upwardForce;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float shutdownHeight;
    [SerializeField]
    private float shutdownDuration;
    [SerializeField]
    private float fuelConsumptionPerNewton;

    Rigidbody2D body;
    FuelTank tank;
    float cooldown = -1.0f;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        tank = GetComponent<FuelTank>();
    }

    private void FixedUpdate()
    {
        cooldown -= Time.fixedDeltaTime;

        if (cooldown > 0.0f)
            return;

        if (tank.IsEmpty())
            return;

        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && body.velocity.y <= maxSpeed)
        {
            body.AddForce(new Vector2(0.0f, upwardForce));
            tank.Burn(upwardForce * fuelConsumptionPerNewton);
        }

        var height = transform.position.y;
        if (height > shutdownHeight)
            cooldown = shutdownDuration;
    }
}
