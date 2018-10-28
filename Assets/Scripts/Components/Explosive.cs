using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private bool removeSelf;
    [SerializeField]
    private GameObject parentToRemove;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private float explosionScale;

    private bool engaged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (engaged)
            return;

        var other = collision.gameObject;
        var health = other.GetComponent<Health>();
        if (!health)
            return;

        engaged = true;
        health.TakeDamage(damage);

        var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(explosionScale, explosionScale, 1.0f);

        if (parentToRemove)
            Destroy(parentToRemove);

        if (removeSelf)
            Destroy(gameObject);
    }
}
