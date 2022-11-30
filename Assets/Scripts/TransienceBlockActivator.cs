using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MariaTsangaris
{
    public class TransienceBlockActivator : MonoBehaviour
    {
        // Needs to know the blocks to activate
        // Needs to know which method to call (TurnTangible, or TurnIntangible)

        [SerializeField] private TransientBlock transientBlockToActivate;
        private void ActivateTransientBlocks()
        {
            // access ALL blocks and turn them tangible.
            // for (int i = 0; i < transientBlockToActivate.Length; i++)
            {
                transientBlockToActivate.TurnTangible();
            } 
        }
    }
}
