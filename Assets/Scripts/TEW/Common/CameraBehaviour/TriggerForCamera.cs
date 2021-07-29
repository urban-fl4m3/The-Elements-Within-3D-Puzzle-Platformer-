using System;
using UnityEngine;

namespace TEW.Common.Camera
{
    public class TriggerForCamera: MonoBehaviour
    {
        [SerializeField] private CameraPoint cameraPoint;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
            if (other.CompareTag("Player"))
            {
                cameraPoint.SetCameraBehaivor();
            }
        }
    }
}