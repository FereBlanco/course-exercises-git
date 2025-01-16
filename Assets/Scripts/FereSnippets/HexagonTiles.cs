using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonTiles : MonoBehaviour
{
    [SerializeField] GameObject hexagonPrefab;
    int rows = 7;
    int cols = 10;
    float width;
    float height;
    float xOffset;
    float yOffset;
    float xStart = -8f;
    float yStart = 4f;

    void Awake()
    {
        width = hexagonPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        xOffset = width / 2;
        height = hexagonPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        yOffset = (float)((height / 2f) * (1f - 1f / Math.Pow(3f,0.5f)));

        for (int i = 0; i < rows; i ++)
        {
            int colsToApply = (i % 2 == 0 ? cols : cols-1);
            for (int j = 0; j < colsToApply; j++)
            {
                float xOffsetToApply = ((i+1) % 2 == 0 ? xOffset : 0f);
                GameObject newGO = Instantiate(hexagonPrefab, new Vector3(xStart + j * width + xOffsetToApply, yStart + (-1) * i * height + (i * yOffset), 0f), Quaternion.identity);
                newGO.name = "H_" + (i+1) + "_" + (j+1);
            }
        }

    }
}
