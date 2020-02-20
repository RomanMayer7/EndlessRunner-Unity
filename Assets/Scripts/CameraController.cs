using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime = 1;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] int lowerLimit=-10;
    [SerializeField] float offset = 2;

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > lowerLimit)
        {

            //the only dimenension of camera which is changes is x(comes from player's position)
            //transform.position = new Vector3 (transform.position.x,player.position.y,transform.position.z);

            //Smooth camera movement
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y+ offset, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
            if (lookAtPlayer == true)
            {
                transform.LookAt(player);
            }

        }
    }
}
