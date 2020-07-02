using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PhysicsEngine : MonoBehaviour
    {
        public Gravity gravity;
        public float timeDialation;
        public void Awake()
        {
            Time.timeScale = timeDialation;
        }
        private void Start()
        {
            gravity = this.GetComponent<Gravity>();
        }
        private void Update()
        {
            Time.timeScale = timeDialation;
        }
    }
}