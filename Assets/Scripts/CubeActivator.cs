using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class CubeActivator : MonoBehaviour
    {
        void Update()
        {
            // If the player presses E...
            if (Input.GetKeyDown(KeyCode.E))
            {
                //...announce the events for the cubes.
                EventsManager.OnChangeColourEvent?.Invoke();
                EventsManager.OnTeleportEvent?.Invoke();
            }
        }
    }
}
