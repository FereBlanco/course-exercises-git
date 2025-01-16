using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Components10 : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] spriteRenderers;
    [SerializeField] Color[] colors;

    private void Awake() {
        if (spriteRenderers.Length == 0 ||
            colors.Length == 0 ||
            spriteRenderers.Length != colors.Length)
        {
            throw new System.Exception("ERROR: Problems with the data arrays!!!");
        }

        for (int i = 0; i < colors.Length; i++)
        {
            if (spriteRenderers[i] != null && colors[i] != null)
            {
                spriteRenderers[i].color = colors[i];
            }
            else
            {
                Debug.Log("E" + i);
            }
        }
    }
}
