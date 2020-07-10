using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class GrapplerTether : MonoBehaviour
    {
        GrapplerHook hook;
        Grappler grappler;
        LineRenderer lineRenderer;

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            grappler = GetComponentInParent<Grappler>();
            hook = grappler.GetComponentInChildren<GrapplerHook>();
        }

        private void Update()
        {
//            lineRenderer.SetPosition(0, grappler.transform.position);
  //          lineRenderer.SetPosition(0, hook.transform.position);
            Debug.DrawLine(grappler.transform.position,hook.transform.position, new Color(160, 128, 64));
        }
    }
}