using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityStandardAssets.Cameras;

namespace Scripts.Animations3DAndImportFromMixamo
{
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] Transform targetTransform;
        private Vector3 offset;

        private void Awake() {
            Assert.IsNotNull(targetTransform, "ERROR: targetTransform is null");
            transform.LookAt(targetTransform);

            offset = transform.position - targetTransform.position;
        }

        void LateUpdate()
        {
            // We write the offset value in Target local coords
            Vector3 newOffset = offset.x * targetTransform.right +
                                offset.y * targetTransform.up +
                                offset.z * targetTransform.forward;
            transform.position = targetTransform.position + newOffset;

            transform.LookAt(targetTransform);
        }
    }
}
