using System;
using UnityEngine;

namespace Helpers.GeyzMechanic
{
    public class CameraRaycaster : MonoBehaviour
    {
        [SerializeField] bool canRotate = false;

        private RayCaster _rayCaster;

        private void Start()
        {
            _rayCaster = new RayCaster(transform, Mathf.Infinity);
            _rayCaster.OnRayEnter += OnRaycastEnter;
            _rayCaster.OnRayExit += OnRaycastExit;
        }

        void Update()
        {
            if (canRotate)
            {
                transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 5);
                transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * 5);
            }
            _rayCaster.SetDirection(transform.TransformDirection(Vector3.forward));
            _rayCaster.CastRay();
        }

        private void OnRaycastEnter(Collider collider)
        {
            if (collider.TryGetComponent(out GeyzObject geyzObject))
            {
                geyzObject.OnCameraStartWatch();
            }
        }

        private void OnRaycastExit(Collider collider)
        {
            if (collider.TryGetComponent(out GeyzObject geyzObject))
            {
                geyzObject.OnCameraEndWatch();
            }
        }
    }
}
