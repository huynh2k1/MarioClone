using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float distance;

    private void Update()
    {
        player = PlayerController.instance.transform;
        transform.position = new Vector3(player.position.x, 3.7f, distance);
    }
}
