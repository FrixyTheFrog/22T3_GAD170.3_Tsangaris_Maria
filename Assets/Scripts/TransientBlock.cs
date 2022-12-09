using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class TransientBlock : MonoBehaviour
    {
        /* 1. Check what state the block is in.
               - If state is tangible, set to intangible.
                    - Disable box collider component.
                    - Change material to “Intangible” material.
               - Else, if state is intangible, set to tangible.
                    - Enable box collider component.
                    - Change material to “Tangible” material.

         */

        public GameObject buttonManager;
        public bool intangible;

        [SerializeField] private GameObject block;
        [SerializeField] private Material tangibleMaterial;
        [SerializeField] private Material intangibleMaterial;

        private void Start()
        {
            buttonManager = GameObject.FindWithTag("Button");

            intangible = false;
        }

        public void OnEnable()
        {
            // The blocks will be called to turn tangible.
            EventsManager.OnTransientBlockButtonPressEvent += TurnTangible;
        }

        public void OnDisable()
        {
            // The blocks won't be called to turn tangible.
            EventsManager.OnTransientBlockButtonPressEvent -= TurnTangible;
        }

        private void Update()
        {
            // When the timer is less than zero set the blocks back to intangible.
            if (buttonManager.GetComponent<InteractableButton>().blockTimer <= 0 && intangible == true)
            {
                TurnIntangible();

                intangible = false;

            }

        }


            public void TurnTangible()
        {
            // If the box collider is disabled...
            if (block.GetComponent<BoxCollider>().enabled == false)
            {
                // ...disable the box collider
                block.GetComponent<BoxCollider>().enabled = true;

                // ...and chnage the material to "Tangible"
                block.GetComponent<MeshRenderer>().material = tangibleMaterial;

                intangible = true;

            }
        }

        private void TurnIntangible()
        {
            // If the box collider is enbaled...
            if (block.GetComponent<BoxCollider>().enabled == true)
            {
                // ...disable the box collider
                block.GetComponent<BoxCollider>().enabled = false;

                // ...and chnage the material to "Intangible"
                block.GetComponent<MeshRenderer>().material = intangibleMaterial;

            }
        }
    }
}

