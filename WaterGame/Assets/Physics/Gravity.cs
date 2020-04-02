using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    public class Gravity : MonoBehaviour
    {
        public Vector2 gravityStrength;

        private Vector2 gravity;
        public Vector2 calculateGravity(Vector3 location)
        {
            gravity.x = gravityStrength.x;
            gravity.y = -gravityStrength.y;
            return gravity;
        }
    }
}
