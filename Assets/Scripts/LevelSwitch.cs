using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitch : MonoBehaviour
{

    // Use this for initialization

    [SerializeField]
    string LeveltoLoad;

      private void OnTriggerStay2D(Collider2D collision)
        {
            // This code gets called each frame player is inside trigger.
            if (collision.gameObject.tag == "Player" && Input.GetButtonDown("Action"))
            {

                    SceneManager.LoadScene(LeveltoLoad);



            }
        }
    }
  
/*  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("You have collided with the Player.");
            NextLevel();
            SceneManager.LoadScene(LeveltoLoad);
        }
    }
         void NextLevel()
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "FirstPrototype":
                    LeveltoLoad = "SecondPrototype";
                    break;
                case "SecondPrototype":
                    LeveltoLoad = "ThirdPrototype";
                    break;
                case "ThirdPrototype":
                    break;


            }

        }
    }*/
