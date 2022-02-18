using System;
using System.Collections;
using UnityEngine;

namespace Helpers.GeyzMechanic
{
    public class RayCaster
    {
        private Transform _startTransform;
        private Transform _endTransform;
        private Vector3 _direction;
        private float _rayLength;

        public event Action<Collider> OnRayEnter;
        public event Action<Collider> OnRayStay;
        public event Action<Collider> OnRayExit;

        Collider previous;
        RaycastHit hit = new RaycastHit();

        public RayCaster(Transform startTransform, float rayLength)
        {
            _startTransform = startTransform;
            _rayLength = rayLength;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public bool CastRay() 
        {
            Physics.Raycast(_startTransform.position, _direction, out hit, _rayLength);
            ProcessCollision(hit.collider);
            Debug.DrawRay(_startTransform.position, _direction);
            return hit.collider != null ? true : false;
        }

        public bool CastLine() 
        {
            Physics.Linecast(_startTransform.position, _endTransform.position, out hit);
            ProcessCollision(hit.collider);
            return hit.collider != null ? true : false;
        }

        private void ProcessCollision(Collider current) 
        {
            if (current == null) 
            {
                if (previous != null) 
                {
                    DoEvent(OnRayExit, previous);
                }
            }

            else if (previous == current) 
            {
                DoEvent(OnRayStay, current);
            }
            else if (previous != null) 
            {
                DoEvent(OnRayExit, previous);
                DoEvent(OnRayEnter, current);
            }
            else 
            {
                DoEvent(OnRayEnter, current);
            }
            
            previous = current;
        }


        private void DoEvent(Action<Collider> action, Collider collider) {
            if (action != null) {
                action(collider);
            }
        }
    }
}