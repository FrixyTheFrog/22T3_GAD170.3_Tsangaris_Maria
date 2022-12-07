using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class EventsManager : MonoBehaviour
    {
        // This will contain all of our events.

        // Event delegates have two parts.
        // The delegate which is the "type of event".
        // The event itself, which gets "announced".

        // This is the type of event we will call.
        public delegate void VoidDelegate();

        // This is the event itself.
        public static VoidDelegate OnTeleportEvent;
        public static VoidDelegate OnChangeColourEvent;
        public static VoidDelegate OnTransientBlockButtonPressEvent;
    }
}
