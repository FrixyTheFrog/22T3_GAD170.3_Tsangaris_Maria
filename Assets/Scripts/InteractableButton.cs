using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class InteractableButton : MonoBehaviour
    {
        public GameObject warningText;
        public bool warningTextPopup;
        public float warningTextTimer;
        public bool canPressButton;

        public float blockTimer;
        public bool blockChecker;
        

        private void Start()
        {
            warningTextPopup = true;
            canPressButton = false;
            blockTimer = 12; // Timer for the transient blocks.
            blockChecker = true;

        }

        private void Update()
        {
            if (warningTextTimer > 0 && warningTextPopup == false)
            {
                warningTextTimer -= Time.deltaTime;
            }

            if (warningTextTimer <= 0 && warningTextPopup == false)
            {
                warningText.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E) && canPressButton == true)
            {
                Debug.Log("e");

                blockChecker = false;

                EventsManager.OnTransientBlockButtonPressEvent?.Invoke();
            }

            if (blockTimer > -1 && blockChecker == false)
            {
                blockTimer -= Time.deltaTime;
            }

            if (blockTimer <= -1 && blockChecker == false)
            {
                blockChecker = true;
                blockTimer = 12; // Timer for the transient blocks.
            }


        }

        public void OnTriggerEnter(Collider other)
        {
            // When inside the trigger can press the interactable button.
            canPressButton = true;

            if (warningTextPopup == true)
            {
                warningText.SetActive(true);
                warningTextTimer = 10;
                warningTextPopup = false;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            // When outside the trigger can't press the interactable button.
            canPressButton = false;
        }
    }
}
