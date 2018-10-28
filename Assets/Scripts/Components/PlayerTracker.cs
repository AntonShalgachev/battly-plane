using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField]
    private float height;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float playerOffset;

    private void Update()
    {
        if (!player)
            return;
        var playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x + playerOffset, height, transform.position.z);
    }
}
