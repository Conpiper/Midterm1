using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth:MonoBehaviour
{
    // public string LeveltoLoad;
    // Use this for initialization
    // public bool Dead;
    // public int health;
    // leveltoload doesnt have a reference to it, making it not call the respawn function.

    // Update is called once per frame
    void Update () 
    {
        if (gameObject.transform.position.y < -7)
     {
         Death();
         //Debug.Log("You are dead");
         //Dead = true;
       /*  if(Dead== true)
         {
             StartCoroutine("Death");
         }*/
     }
	}
    //A lab worker introduced me to IEnumerator, its similar to a method or function.
    void Death()
    {
       /* Script that wasnt working out
        Debug.Log("Treachery is afoot!");
        yield return new WaitForSeconds(3);
        Debug.Log("DEATH!");
        */
        SceneManager.LoadScene("FirstPrototype");
        //Debug.Log("The level has been reset.");
   
    }
}
