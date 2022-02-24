using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // To keep the player stick to moving platform. 
    private void OnCollisionEnter(Collision collision)
    {
        //If platform collides with player, set the player as child of the platform. This script is under floor 4
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Unparenting from moving platform
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
