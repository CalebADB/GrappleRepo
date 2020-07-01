using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LocalCollisionManager : MonoBehaviour
    {
        public LayerMask collisionMask;

        public new BoxCollider2D collider;
        public CollisionData collisionData;
        private RaycastOrigins raycastOrigins;

        // debug values
        public float debugRayMultiplier;

        const float skinWidth = 0.015f;

        public int vertRayCount;
        private float vertRaySpacing;
        public int horzRayCount;
        private float horzRaySpacing;

        Vector2 rayOrigin;

        private void Start()
        {
            collider = this.GetComponent<BoxCollider2D>();
            calculateRaySpacing();
        }

        public Vector2 updateManager(Vector2 displacement)
        {
            updateRaycastOrigins();

            updateHorzCollision(displacement);
            updateVertCollision(displacement);

            if (collisionData.horzCollision || collisionData.vertCollision)
            {
                return getCollisionDisplacement(displacement);
            }
            return displacement;
        }

        private void updateRaycastOrigins()
        {
            Bounds bounds = collider.bounds;

            // subtracts skin width
            bounds.Expand(skinWidth * -2);

            // Set bounds for collision with skinwidth
            raycastOrigins.bottomLeft.Set(bounds.min.x, bounds.min.y);
            raycastOrigins.bottomRight.Set(bounds.max.x, bounds.min.y);
            raycastOrigins.topLeft.Set(bounds.min.x, bounds.max.y);
            raycastOrigins.topRight.Set(bounds.max.x, bounds.max.y);
        }

        private void updateHorzCollision(Vector2 displacement)
        {
            collisionData.horzCollision = false;

            Vector2 direction = Vector2.right * Mathf.Sign(displacement.x);
            float rayLength = Mathf.Abs(displacement.x) + skinWidth;

            rayOrigin = (direction.x == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;

            for (int i = 0; i < horzRayCount; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, rayLength, collisionMask);

                if (hit)
                {
                    collisionData.horzCollision = true;
                    rayLength = hit.distance;
                }

                Debug.DrawRay(rayOrigin, direction * rayLength * debugRayMultiplier, Color.magenta);
                rayOrigin.y += horzRaySpacing;
            }
            collisionData.horzCollisionDistance = (rayLength - skinWidth) * direction.x;
        }

        private void updateVertCollision(Vector2 displacement)
        {
            collisionData.vertCollision = false;

            Vector2 direction = Vector2.up * Mathf.Sign(displacement.y);
            float rayLength = (displacement.y * -1) + skinWidth;

            for (int i = 0; i < vertRayCount; i++)
            {
                rayOrigin = (direction.y == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (vertRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, rayLength, collisionMask);

                if (hit)
                {
                    collisionData.vertCollision = true;
                    rayLength = hit.distance;
                }

                Debug.DrawRay(rayOrigin, direction * rayLength * debugRayMultiplier, Color.magenta);
            }
            collisionData.vertCollisionDistance = (rayLength - skinWidth) * direction.y;
        }

        public Vector2 getCollisionDisplacement(Vector2 displacement)
        {
            if (collisionData.horzCollision)
            {
                displacement.x = collisionData.horzCollisionDistance;
            }
            if (collisionData.vertCollision)
            {
                displacement.y = collisionData.vertCollisionDistance;
            }

            return displacement;
        }

        private void calculateRaySpacing()
        {
            Bounds bounds = collider.bounds;

            // subtract skin width
            bounds.Expand(skinWidth * -2);

            // make sure theres a minimum of 2 rays
            horzRayCount = Mathf.Clamp(horzRayCount, 2, int.MaxValue);
            vertRayCount = Mathf.Clamp(vertRayCount, 2, int.MaxValue);

            // caleculate ray spacing
            horzRaySpacing = bounds.size.y / (horzRayCount - 1);
            vertRaySpacing = bounds.size.x / (vertRayCount - 1);
        }

        public struct CollisionData
        {
            public bool horzCollision;
            public float horzCollisionDistance;
            public bool vertCollision;
            public float vertCollisionDistance;
        }

        private struct RaycastOrigins
        {
            public Vector2 topLeft, topRight, bottomLeft, bottomRight;
        }
    }
}

