using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MariaTsangaris
{
    public class Spikes : MonoBehaviour
    {

        public GameObject spawnpointOne;
        public GameObject spawnpointTwo;
        public Transform playerTransform;
        public GameObject player;
        public GameObject checkpointManager;
        public bool endButton;
        public string myScene;


        public void Start()
        {
            player = this.gameObject;
            // This allows for the game object to be found with specific tags.
            spawnpointOne = GameObject.FindWithTag("Spawn");
            spawnpointTwo = GameObject.FindWithTag("SpawnTwo");
            checkpointManager = GameObject.FindWithTag("Manager");

        }

        public void Update()
        {
            // If 'E' key is pressed within the end button on enter trigger...
            if(Input.GetKeyDown(KeyCode.E) && endButton == true)
            {
                // ... reload the scene.
                SceneManager.LoadScene(myScene);
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            // If play collides with gameobject that has "Spike" tag.
            if(other.transform.tag == "Spike")
            {

                // If the play dies with without activating the checkpoint...
                if(checkpointManager.GetComponent<Checkpoint>().spawnLocation == 0)
                {
                    // ... move the player back to Spawnpoint1.
                    Instantiate(player, new Vector3(spawnpointOne.transform.position.x, spawnpointOne.transform.position.y, spawnpointOne.transform.position.z), Quaternion.identity);

                    Debug.Log("Died. Spawnpoint1");
                }

                // If the play dies with after activating the checkpoint...
                if (checkpointManager.GetComponent<Checkpoint>().spawnLocation == 1)
                {
                    // ... move the player back to Spawnpoint2.
                    Instantiate(player, new Vector3(spawnpointTwo.transform.position.x, spawnpointTwo.transform.position.y, spawnpointTwo.transform.position.z), Quaternion.identity);

                    Debug.Log("Died. Spawnpoint2");
                }

                Destroy(this.gameObject);

            }
            // If play collides with gameobject that has "CheckpointOne" tag...
            if (other.transform.tag == "CheckpointOne")
            {
                // ... move the players spawnpoint1 to Spawnpoint2.
                checkpointManager.GetComponent<Checkpoint>().spawnLocation = 1;

                Debug.Log("Changed: From Spawnpoint1 to Spawnpoint2");
            }
            // If the tag is "CheckpointTwo" change to 
            if (other.transform.tag == "CheckpointTwo" && checkpointManager.GetComponent<Checkpoint>().spawnLocation != 2)
            {
                checkpointManager.GetComponent<Checkpoint>().spawnLocation = 2;

                checkpointManager.GetComponent<Checkpoint>().gameWon = true;

                Debug.Log("CheckpointTwo ");
            }
            // If the player is within the trigger...
            if (other.transform.tag == "EndButton")
            {
                // ... the end button can be interacted with.
                endButton = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            // If the player is within the trigger...
            if (other.transform.tag == "EndButton")
            {
                // ... the end button cannot be interacted with.
                endButton = false;
            }
        }

    }
}
