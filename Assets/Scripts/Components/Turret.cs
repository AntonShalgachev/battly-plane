using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float angle;
    [SerializeField]
    private float delay;
    [SerializeField]
    private GameObject player;

    private GameObject parent;

    private float cooldown = -1.0f;

    private void Awake()
    {
        parent = new GameObject("Turret Projectiles");
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown > 0.0f)
            return;

        //var angle = CalculateAngle();

        if (!float.IsNaN(angle))
            Shoot(angle * Mathf.Deg2Rad);

        cooldown = delay;

        //Debug.Log(angle);
    }

    private float CalculateAngle()
    {
        var g = Physics2D.gravity.y;
        var x0 = player.transform.position.x - transform.position.x;
        var y0 = player.transform.position.y - transform.position.x;

        Debug.Log(string.Format("position={0}", new Vector2(x0, y0)));

        var k = (g * x0 * x0) / (2.0f * speed * speed);
        var a = y0 * y0 + x0 * x0;
        var b = 2.0f * k * y0 - x0 * x0;
        var d = b * b - 4 * a * k * k;

        Debug.Log(string.Format("D={0}", d));

        var t1 = (-b + Mathf.Sqrt(d)) / (2.0f * a);
        var t2 = (-b - Mathf.Sqrt(d)) / (2.0f * a);

        Debug.Log(string.Format("t = {0} or {1}", t1, t2));

        var a1 = Mathf.Acos(Mathf.Sqrt(t1)) * Mathf.Rad2Deg;
        var a2 = Mathf.Acos(-Mathf.Sqrt(t1)) * Mathf.Rad2Deg;
        var a3 = Mathf.Acos(Mathf.Sqrt(t2)) * Mathf.Rad2Deg;
        var a4 = Mathf.Acos(-Mathf.Sqrt(t2)) * Mathf.Rad2Deg;

        Debug.Log(string.Format("a = {0} or {1} or {2} or {3}", a1, a2, a3, a4));

        var angle = a1;

        return angle;
    }

    private void Shoot(float angle)
    {
        var projectile = Instantiate(projectilePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, parent.transform);
        var body = projectile.GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));
    }
}
