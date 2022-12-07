using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class Teleporter : MonoBehaviour
    {
        // This cube will teleport when the "OnTeleporterEvent" event is announced
        // Teleport will move the cube to a random position on the Y axis.

        private void OnEnable()
        {
            EventsManager.OnTeleportEvent += Teleport;
        }

        private void OnDisable()
        {
            EventsManager.OnTeleportEvent -= Teleport;
        }

        private void Teleport()
        {
            transform.position = new Vector3(2, Random.Range(0.75f, 4f), 0f);
        }

    }

}
