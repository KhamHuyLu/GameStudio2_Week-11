using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;

        private Vector3 checkpointPosition;

        void Start()
        {
            player = playerGameObject.GetComponent<PlayerController>();
            checkpointPosition = playerGameObject.transform.position;
        }

        void Update()
        {
            if (player.deathState == true)
            {
                playerGameObject.SetActive(false);
                GameObject deathPlayer = Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                playerGameObject.transform.position = checkpointPosition;
                Invoke("ReloadLevel", 3);
            }
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void SetCheckpoint(Vector3 position)
        {
            checkpointPosition = position;
        }
    }
}