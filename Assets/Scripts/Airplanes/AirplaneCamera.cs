using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.Airplanes
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform targetTransform;
        private Vector3 offset;

        private void Awake() {
            Assert.IsNotNull(targetTransform, "ERROR: targetTransform is null");    
            offset = transform.position - targetTransform.position;
        }

        void LateUpdate()
        {
            // Camera changes x and y values but retains z
            transform.position = new Vector3(transform.position.x, transform.position.y, targetTransform.position.z + offset.z);
        }
    }
}
