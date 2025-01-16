using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Animations3DAndImportFromMixamo
{

    public class WrestlerGenerator : MonoBehaviour
    {
        [SerializeField] GameObject ragdollPrefab;
        [SerializeField] float height = 40f;
        [SerializeField] float time = 0.001f;
        [SerializeField] int maxWestlersByStep = 10;


        void Awake()
        {
            CreateWrestlerRagdoll();
        }

        IEnumerator CreateWrestlerTimer()
        {
            yield return new WaitForSeconds(time);
            CreateWrestlerRagdoll();
        }

        void CreateWrestlerRagdoll()
        {
            for (int i = 1; i < maxWestlersByStep; i++)
            {
                Instantiate(ragdollPrefab, new Vector3(Random.Range(-5f, 5f), height, Random.Range(-5f, 5f)), Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));
            }
            StartCoroutine(CreateWrestlerTimer());
        }
    }
}
