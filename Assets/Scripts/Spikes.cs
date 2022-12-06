using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class Spikes : MonoBehaviour
    {

        public GameObject spawnpoint;
        public GameObject spawnpointTwo;
        public Transform playerTransform;
        public GameObject player;
        public GameObject checkpointManager;

        public void Start()
        {
            player = this.gameObject;
            spawnpoint = GameObject.FindWithTag("Spawn");
            spawnpointTwo = GameObject.FindWithTag("SpawnTwo");
            checkpointManager = GameObject.FindWithTag("Manager");

        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag == "Spike")
            {
                Debug.Log("Spike Has Been Collided With");

                if(checkpointManager.GetComponent<Checkpoint>().spawnLocation == 0)
                {
                    Instantiate(player, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
                }

                if (checkpointManager.GetComponent<Checkpoint>().spawnLocation == 1)
                {
                    Instantiate(player, new Vector3(spawnpointTwo.transform.position.x, spawnpointTwo.transform.position.y, spawnpointTwo.transform.position.z), Quaternion.identity);
                }

                Destroy(this.gameObject);

            }

            if (other.transform.tag == "CheckpointOne")
            {
                checkpointManager.GetComponent<Checkpoint>().spawnLocation = 1;

                Debug.Log("Spawnpoint1");
            }
        }

    }
}
