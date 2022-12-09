using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class Checkpoint : MonoBehaviour
    {

        public int spawnLocation = 0;

        public GameObject barrier;
        public GameObject endGameText;

        public bool gameWon;

        void Start()
        {
            gameWon = false;
        }

        void Update()
        {
            if (gameWon == true)
            {
                barrier.SetActive(true);
                endGameText.SetActive(true);

                gameWon = false;
            }
        }
    }
}
