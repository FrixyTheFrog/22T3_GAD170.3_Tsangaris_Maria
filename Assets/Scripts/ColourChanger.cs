using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class ColourChanger : MonoBehaviour
    {
        // This cube will change colours when the "OnChangeColourEvent" event is announced
        // Change colours will change the cubes colour to a new colour.

        private void Start()
        {
            ChangeColour();
        }

        private void OnEnable()
        {
            EventsManager.OnChangeColourEvent += ChangeColour;
        }

        private void OnDisable()
        {
            EventsManager.OnChangeColourEvent -= ChangeColour;
        }

        private void ChangeColour()
        {
            float redValue = Random.Range(0f, 1f);
            float greenValue = Random.Range(0f, 1f);
            float blueValue = Random.Range(0f, 1f);

            gameObject.GetComponent<MeshRenderer>().material.color = new Color(redValue, greenValue, blueValue);
        }
    }
}
