using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Checkpoint : MonoBehaviour
    {
        private GameManager gameManager;

        void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameManager.SetCheckpoint(transform.position); // set the checkpoint position to the current position of the checkpoint game object
            }
        }
    }
}
