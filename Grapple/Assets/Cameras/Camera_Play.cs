using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class Camera_Play : MonoBehaviour
    {
        public CameraGrip cameraGrip;
        public Camera camera;
        public CameraShaker cameraShaker;

        // Start is called before the first frame update
        void Start()
        {
            cameraGrip = this.GetComponentInParent<CameraGrip>();
            camera = this.GetComponent<Camera>();
            cameraShaker = this.GetComponent<CameraShaker>();
        }

        // Update is called once per frame
        void Update()
        {
            cameraShaker.shake();
        }
    }
}