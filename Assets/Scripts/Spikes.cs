using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField] private int hitdamage;
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Spike Has Been Collided With");
        }
    }
}
