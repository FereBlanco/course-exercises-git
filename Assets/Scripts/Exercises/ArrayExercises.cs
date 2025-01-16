using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ArrayExercises : MonoBehaviour
{
    // public int[] arrayInt = {1, 2, 3};
    // public List<int> listInt = new List<int>() {1, 2, 3};
    // public int[] arrayInt2 = {4, 5, 6};

    [SerializeField] int[] arrayInt = {1, 2, 0, 3, 4, 5};
    [SerializeField] float[] arrayFloat = {1f, 2f, 0f, 3f, 4f, 5f};

    // [SerializeField] bool[] arrayBool;
    // [SerializeField] String sentence = "Yo tengo un murciélago. TÚ TIENES UN MURCIÉLAGO.";

    void Awake()
    {
        // CheckIfArrayIsOrdered(arrayFloat);

        // Debug.Log($"List {listToString(listInt)}.");
        // listInt.Add(4);
        // listInt.Add(5);
        // listInt.Add(6);
        // Debug.Log($"List {listToString(listInt)}.");

        // Debug.Log($"There are {HowManyTrues(arrayBool)} true values in a total of {arrayBool.Length} bool values.");

        // Debug.Log($"Sencente: {sentence}");
        // Debug.Log($"Number of vocals in sentece: \"{HowManyVocals(sentence)}\"");

        // Debug.Log($"Array: {ArrayToString(arrayFloat)}");
        // Debug.Log($"Average: {ArrayAddiction(arrayFloat)} / {arrayFloat.Length} = {ArrayAverage(arrayFloat)}");

        Debug.Log($"Array: {GenericArrayToString(arrayInt)}");
        Debug.Log($"Average: {GenericArrayAddiction(arrayInt)} / {arrayInt.Length} = {GenericArrayAverage(arrayInt)}");
        Debug.Log("-");
        Debug.Log($"Array: {GenericArrayToString(arrayFloat)}");
        Debug.Log($"Average: {GenericArrayAddiction(arrayFloat)} / {arrayFloat.Length} = {GenericArrayAverage(arrayFloat)}");
    }
    
    private float ArrayAverage(float[] array)
    {
        if (array == null || array.Length == 0) throw new Exception("ERROR: Invalid array!!!");
        return RoundFloatWithDecimals(ArrayAddiction(array)/array.Length, 2);
    }

    private float GenericArrayAverage<T>(T[] array) where T : struct, IComparable
    {
        if (array == null || array.Length == 0) throw new Exception("ERROR: Invalid array!!!");
        return RoundFloatWithDecimals((float)GenericArrayAddiction(array)/array.Length, 2);
    }

    private float ArrayAddiction(float[] array)
    {
        if (array == null || array.Length == 0) throw new Exception("ERROR: Invalid array!!!");
        float arrayAddiction = 0f;
        foreach(float f in array) arrayAddiction += f;
        return arrayAddiction;
    }

    private float GenericArrayAddiction<T>(T[] array) where T : struct, IComparable
    {
        if (array == null || array.Length == 0) throw new Exception("ERROR: Invalid array!!!");
        float arrayAddiction = 0f;
        // foreach(dynamic item in array) arrayAddiction += (float)item;
        return arrayAddiction;
    }

    private float RoundFloatWithDecimals(float number, float decimals)
    {
        return ((float)Math.Round(number*Mathf.Pow(10,decimals))/Mathf.Pow(10,decimals));
    }

    private String GenericArrayToString<T>(T[] array) where T : struct, IComparable
    {
        String newArray = "[ ";
        foreach (var item in array)
        {
            newArray += item + " ";
        }
        newArray += "]";
        return newArray;
    }

    private int HowManyVocals(String sentence)
    {
        if (sentence == null || (sentence.Length == 0)) throw new Exception("ERROR: Invalid sentence!!!");

        List<char> vocals = new List<char> {'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'ü'};
        int counter = 0;
        String vocalsInSentence = "-";
        foreach (char c in sentence)
        {
            if (vocals.Contains(char.ToLower(c)))
            {
                counter++;
                vocalsInSentence += c + "-";
            }
        }
        Debug.Log("Vocals in sentence: " + vocalsInSentence);
        return counter;
    }

    private int HowManyTrues(bool[] array)
    {
        if (array.Length == 0) throw new Exception("ERROR: The array has no elements.");
        
        int counter = 0;
        foreach (bool elem in array)
        {
            if (elem) counter++;
        }
        return counter;
    }

    private string ArrayToString(int[] array)
    {
        String arrayString = "( ";
        foreach (int elem in array)
        {
            arrayString += elem + " ";
        }
        arrayString += ")";
        return arrayString;
    }

    private string ArrayToString(float[] array)
    {
        String arrayString = "( ";
        foreach (float elem in array)
        {
            arrayString += elem + " ";
        }
        arrayString += ")";
        return arrayString;
    }

    private string listToString(List<int> list)
    {
        String listString = "( ";
        foreach (int elem in list)
        {
            Debug.Log(elem);
            listString += elem + " ";
        }
        listString += ")";
        return listString;
    }

    private bool ElementIsOrdered(float[] array, int position)
    {
        if (position == 0)
        {
            return (array[position] <= array[1]);
        }
        else if (position == array.Length - 1)
        {
            return (array[array.Length-2] <= array[position]);
        }
        else
        {
            return ((array[position-1] <= array[position]) && (array[position] <= array[position+1]));
        }
    }

    private void CheckIfArrayIsOrdered(float[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log($"The element {i} of the array is {(ElementIsOrdered(array,i) ? "": " not ")} ordered.");
        }
    }


}
