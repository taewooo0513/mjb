using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetX = 0;
    [SerializeField] private float offsetY = -15;
    [SerializeField] private float offsetZ = 15;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x - offsetX, player.position.y - offsetY, player.position.z - offsetZ);
        transform.LookAt(player);
    }
}
