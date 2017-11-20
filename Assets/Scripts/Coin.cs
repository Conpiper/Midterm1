using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    // Step 1: declare variables
    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;


    
    public static int coinCount = 0;

    private void Start()
    {
        // Step 2: initialize variables
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Coin touched!");
            audioSource.Play();
            boxCollider2D.enabled = false;
            spriteRenderer.enabled = false;

            float length = audioSource.clip.length + 0.2f;

            // Increment coint count!
            coinCount++;

            Debug.Log("Coin count: " + coinCount);

            Destroy(gameObject, length);
        }
    }

}
