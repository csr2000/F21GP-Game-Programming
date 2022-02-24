using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    private void Update()
    {
        //Check if player falls of platform after a certain height, it dies. 
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //When you have more than one enemy, instead of comapring enemy 1,2 compare tags. So here if you collide with enemy body you die. 
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Make the player dissappear from scene. 
            GetComponent<MeshRenderer>().enabled = false; //Disables the mesh rendered and we won't be able to see the player. 
            GetComponent<Rigidbody>().isKinematic = true; //Under Rigid Body
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }
    void Die()
    {

        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;

    }

    void ReloadLevel()
    {
        //Load current level. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
