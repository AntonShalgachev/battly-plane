using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private GameObject bombSpawnPoint;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameController.Instance.IsGameActive())
            return;

        if (Input.GetKeyDown(KeyCode.Return))
            DropBomb();
    }

    private void DropBomb()
    {
        var bomb = Instantiate(bombPrefab, bombSpawnPoint.transform.position, transform.rotation);
        var bombBody = bomb.GetComponentInChildren<Rigidbody2D>();
        bombBody.velocity = body.velocity;
    }
}
