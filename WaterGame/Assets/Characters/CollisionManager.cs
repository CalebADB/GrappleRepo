using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionManager : MonoBehaviour
    {
        public BoxCollider2D boxCollider2D;

        private void Start()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }
    }
}

