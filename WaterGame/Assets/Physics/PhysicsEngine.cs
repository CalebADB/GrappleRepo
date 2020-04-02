using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PhysicsEngine : MonoBehaviour
    {
        public Gravity gravity;
        private void Start()
        {
            gravity = this.GetComponent<Gravity>();
        }
    }
}