using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

// with Monday = 1 I change the ordinal of the elements, from 0..6 (default) to 1..7 >> I can use them with casting: (int)Weekdays.Wednesday 
public enum WeekDays {Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday};

public class Basicos : MonoBehaviour
{
    // int number1 = 12;
    // int number2 = 7;
    // int multipleBase = 3;

    // [SerializeField] private float floatNumber1 = 0.4f;
    // [SerializeField] private float floatNumber2 = 2f;
    // [SerializeField] private float floatStep = 0.1f;
    // [SerializeField] private int decimales = 2;

    // [SerializeField] private float[] weights;
    // [SerializeField] private float limit1;
    // [SerializeField] private float limit2;
    [SerializeField] private float[] floatNumbers;

    // [SerializeField] int[] numbers;

    public void Awake()
    {
        // Basico1();

        // Basico2();

        // Basico3(5, 5);
        // Basico3(6, 5);

        // Basico4(0);
        // Basico4(-1);
        // Basico4(1);

        // Basicos5(6);
        // Basicos5(5);

        // int[] numeros = { -1, -2, 0, 1, 2, 3 };
        // Basico6(numeros);

        // Bucle01While();
        // Bucle02For();
        // Bucle03For();

        // Bucle04Multiplos(40, 80, 7);
        // Bucle05Multiplos2Numeros(1, 9999, 131, 15);

        // int[] numeros2 = { 5, 6, 2, 9, 12, 2, 15, 7, 8 };
        // Basico7MenorMayor(numeros2);

        // int[] numbers = { 5, 4, -3, 0, 2 };
        // AddPositivesMultiplyNegatives(numbers);

        // isMultipleOfText(25, 5);
        // isMultipleOfText(25, 4);

        // evenNumbersInAnInterval(11, 19);

        // for (int i = 1; i <= 8; i++)
        // {
        //     // Debug.Log($"Op1: The name of the {i}{GetOrdinal(i)} day of the week is {GetDay(i)}.");
        //     Debug.Log($"Op2: The name of the {i}{GetOrdinal(i)} day of the week is {GetDay2(i)}.");
        // }

        // for (int i = 3; i <= 7; i++)
        // {
        //     Debug.Log($"The name of the polygon with {i} sides is {Polygon(i)}.");
        // }

        // Debug.Log($"First number value is {number1} and second value is {number2}.");
        // int aux = number1;
        // number1 = number2;
        // number2 = aux;
        // Debug.Log($"First number value is {number1} and second value is {number2}.");

        // Debug.Log($"The addition of every number lower than {number1} if {NumberAddiction(number1)}.");
        // Debug.Log($"The addition of every number lower than {number2} if {NumberAddiction(number2)}.");

        // ShowNumbers(number1, number2);
        // ShowNaturalNumbersBetween(number1, number2);

        // MultiplesOf(number1, number2, multipleBase);
        // ShowFloatsBetween(floatNumber1, floatNumber2, floatStep);

        // Debug.Log($"The square of {floatNumber1} is {Mathf.Pow(floatNumber1,2)} and its cube is {Mathf.Pow(floatNumber1,3)}.");

        // Debug.Log($"The perimeter of the circle with radius = {floatNumber1} is {RoundFloatWithDecimals(CirclePerimeter(floatNumber1),decimales)} and its area is {RoundFloatWithDecimals(CircleArea(floatNumber1),decimales)}");
        // Debug.Log($"The perimeter of the circle with radius = {floatNumber1} is {RoundFloatWithDecimals(CirclePerimeter(floatNumber1),decimales+1)} and its area is {RoundFloatWithDecimals(CircleArea(floatNumber1),decimales+1)}");
        // Debug.Log($"The perimeter of the circle with radius = {floatNumber1} is {RoundFloatWithDecimals(CirclePerimeter(floatNumber1),decimales+2)} and its area is {RoundFloatWithDecimals(CircleArea(floatNumber1),decimales+2)}");
        // Debug.Log($"The perimeter of the circle with radius = {floatNumber1} is {RoundFloatWithDecimals(CirclePerimeter(floatNumber1),decimales+3)} and its area is {RoundFloatWithDecimals(CircleArea(floatNumber1),decimales+3)}");

        // PeopleWeight(weights, limit1, limit2);

        // Debug.Log($"The total addiction of the elements of the array is {ArrayAddiction(numbers)}.");

        // Debug.Log($"The surface of a triangle with floor {3} and height {4} is {TriangleSurface(3,4)}.");
        // Debug.Log($"The surface of a triangle with floor {5} and height {8} is {TriangleSurface(5,8)}.");
        // Debug.Log($"The surface of a triangle with floor {6} and height {10} is {TriangleSurface(6,10)}.");

        // MultiplicationTable(-1);
        // MultiplicationTable(0);
        // MultiplicationTable(7);
        // MultiplicationTable(11);

        // if ((numException <= 0) || (numException > 10)) throw new Exception("ERROR: invalid number.");

        // var positiveCounter = floatNumbers.Where(value => value > 0);
        // IEnumerable<float> positiveCounterIE = floatNumbers.Where(value => value > 0);
        // int positiveCounterC = floatNumbers.Count(value => value > 0);


    }



    private void MultiplicationTable(int n)
    {
        if ((n <= 0) || (n > 10))
        {
            throw new Exception($"ERROR: invalid number ({n}).");
        }
        else
        {
            for (int i = 1; i <= 10; i++)
            {
                Debug.Log($"{n} multiplied by {i} is {n * i}.");
            }
        }
    }

    private float TriangleSurface(float floor, float height)
    {
        return RoundFloatWithDecimals(floor * height / 2, 3);
    }

    private int ArrayAddiction(int[] arrayToAdd)
    {
        int arrayAddiction = 0;
        foreach (var value in arrayToAdd)
        {
            arrayAddiction += value;
        }
        return (arrayAddiction);
    }
    private void PeopleWeight(float[] weights, float limit1, float limit2)
    {
        int lessThanLimit1 = 0;
        int betweenLimit1andLimit2 = 0;
        int moreThanLimit2 = 0;
        foreach(var weight in weights)
        {
            if (weight < limit1)
            {
                lessThanLimit1++;
            }
            else if (weight > limit2)
            {
                moreThanLimit2++;
            }
            else
            {
                betweenLimit1andLimit2++;
            }
        }
        Debug.Log($"There are {lessThanLimit1} people who weigh less than {limit1} kilos, {betweenLimit1andLimit2} people who weigh between {limit1} and {limit2} kilos, and {moreThanLimit2} people who weigh more than {limit2} kilos.");
    }

    private float CirclePerimeter(float r)
    {
        return (2 * Mathf.PI * r);
    }

    private float CircleArea(float r)
    {
        return (Mathf.PI * Mathf.Pow(r,2));
    }

    private float RoundFloatWithDecimals(float number, float decimals)
    {
        return ((float)Math.Round(number*Mathf.Pow(10,decimals))/Mathf.Pow(10,decimals));
    }

    private void ShowFloatsBetween(float num1, float num2, float step)
    {
        float lower = (num1 <= num2 ? num1 : num2);
        float higher = (num1 >= num2 ? num1 : num2);
        String answer = "";
        for (float i = lower + step; i < higher; i += step)
        {
            Debug.Log(Math.Round(i*10)/10);
            answer += "   " + Math.Round(i*10)/10;
        }
        Debug.Log("Answer: " + answer);
    }
    private void MultiplesOf(int numberA, int numberB, int numberBase)
    {
        int higher = (numberA > numberB ? numberA : numberB);
        int lower = (numberA < numberB ? numberA : numberB);
        int counter = 0;
        for (int i = lower; i <= higher; i++)
        {
            if (IsMultipleOf(i, numberBase))
            {
                counter++;
            }
        }
        Debug.Log($"There are {counter} multiples of {numberBase} between {lower} and {higher}.");
    }

    private void ShowNumbers(int numberA, int numberB)
    {
        int higher = (numberA > numberB ? numberA : numberB);
        int lower = (numberA < numberB ? numberA : numberB);
        String numberList = "";
        for (int i = lower; i <= higher; i++)
        {
            numberList += " " + i;
        }
        Debug.Log(numberList);
    }
    private void ShowNaturalNumbersBetween(int numberA, int numberB)
    {
        int higher = (numberA > numberB ? numberA : numberB);
        int lower = (numberA < numberB ? numberA : numberB);
        String numberList = "";
        for (int i = lower+1; i < higher; i++)
        {
            numberList += " " + i;
        }
        Debug.Log(numberList);
    }

    private int NumberAddiction(int number)
    {
        int add = 0;
        for (int i = (number-1); i > 0; i--)
        {
            add += i;
        }
        return add;
    }

    private string GetDay(int numDay)
    {
        String stringDay;
        switch (numDay)
        {
            case 1:
                stringDay = WeekDays.Monday.ToString();
                break;
            case 2:
                stringDay = WeekDays.Tuesday.ToString();
                break;
            case 3:
                stringDay = WeekDays.Wednesday.ToString();
                break;
            case 4:
                stringDay = WeekDays.Thursday.ToString();
                break;
            case 5:
                stringDay = WeekDays.Friday.ToString();
                break;
            case 6:
                stringDay = WeekDays.Saturday.ToString();
                break;
            case 7:
                stringDay = WeekDays.Sunday.ToString();
                break;
            default:
                stringDay = "[UNKNOWN]";
                break;
        }
        return stringDay;
    }
    private string GetDay2(int numDay)
    {
        if ((numDay >= 1) && (numDay <= 7))
        {
            return Enum.GetValues(typeof(WeekDays)).GetValue(numDay-1).ToString();
        }
        else
        {
            return "[UNKNOWN]";
        }
    }

    private string GetOrdinal(int number)
    {
        if ((number-1) % 10 == 0)
        {
            return "st";
        }
        else if ((number-2) % 10 == 0)
        {
            return "nd";
        }
        else if ((number-3) % 10 == 0)
        {
            return "rd";
        }
        else
        {
            return "th";
        }
    }

    private string Polygon(int sideNumber)
    {
        switch (sideNumber)
        {
            case 3:
                return "Triangle";
            case 4:
                return "Square";
            case 5:
                return "Pentagon";
            case 6:
                return "Hexagon";
            default:
                return "[UNKOWN]";
        }

    }

    private void Bucle01While()
    {
        int iterador = 0;
        while (iterador <= 100)
        {
            Debug.Log($"while: {iterador}");
            iterador++;
        }
    }

    private void Bucle02For()
    {
        for (int iterador = 0; iterador <= 100; iterador++)
        {
            Debug.Log($"for: {iterador}");
        }
    }

    private void Bucle03For()
    {
        for (int iterador = 100; iterador >= 0; iterador--)
        {
            Debug.Log($"for: {iterador}");
        }
    }

    private void Bucle04Multiplos(int start, int end, int numBase)
    {
        if (start < end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % numBase == 0)
                {
                    Debug.Log($"El número {i} es múltiplo de {numBase}.");
                }
            }
        }
        else
        {
            Debug.Log("El número inicial ha de ser menor que el número final.");
        }
    }
    private void Bucle05Multiplos2Numeros(int start, int end, int numBase1, int numBase2)
    {
        if (start < end)
        {
            String answer = "[";

            //--- FOR version
            for (int i = start; i <= end; i++)
            {
                if ((i % numBase1 == 0) && (i % numBase2 == 0))
                {
                    answer += " " + i;
                }
            }

            //--- WHILE version
            // int i = start;
            // while (i <= end)
            // {
            //     if ((i % numBase1 == 0) && (i % numBase2 == 0))
            //     {
            //          answer += " " + i;
            //     }
            //     i++;
            // }

            answer += " ]";
            Debug.Log(answer);
        }
        else
        {
            Debug.Log("El número inicial ha de ser menor que el número final.");
        }
    }

    private void Basico7MenorMayor(int[] numeros)
    {
        if (numeros.Length > 1)
        {
            int menor = numeros.ElementAt(0);
            int mayor = numeros.ElementAt(0);
            for (int i = 1; i < numeros.Length; i++)
            {
                if (menor > numeros.ElementAt(i)) menor = numeros.ElementAt(i);
                if (mayor < numeros.ElementAt(i)) mayor = numeros.ElementAt(i);
            }
            Debug.Log($"El número menor es {menor} y el número mayor es {mayor}.");
        }
        else
        {
            Debug.Log("La matriz de números está vacía.");
        }
    }

    private bool IsMultipleOf(int number, int multipleOf)
    {
        return (number % multipleOf == 0);
    }

    private void IsMultipleOfText(int number, int multiple)
    {
        Debug.Log($"The number {number} is {((number % multiple == 0) ? "" : "NOT")} multiple of {multiple}.");
    }

    private bool isEven(int number)
    {
        return (number % 2 == 0);
    }

    private void evenNumbersInAnInterval(int start, int end)
    {
        String answer = "";
        for (int i = start; i <= end; i++)
        {
            if (isEven(i))
            {
                answer += " " + i;
            }
        }
        Debug.Log(answer);
    }

    private void AddPositivesMultiplyNegatives(int[] numbers)
    {
        int addition = 0;
        int multiply = 1;
        foreach (int number in numbers)
        {
            if (number >= 0)
            {
                addition += number;
            }
            else
            {
                multiply *= number;
            }
        }
        Debug.Log($"Addition: {addition}, Multiply: {multiply}");
    }

    private void Basico6(int[] numeros)
    {
        string cadena = "[";
        int positivos = 0;
        int negativos = 0;
        int ceros = 0;
        foreach (int numero in numeros)
        {
            cadena += numero + ",";
            if (numero > 0) positivos++;
            if (numero < 0) negativos++;
            if (numero == 0) ceros++;
        }
        cadena += "]";
        Debug.Log(cadena);
        Debug.Log($"positivos: {positivos}, negativos: {negativos}, ceros: {ceros}");
    }
    private void Basicos5(int numero)
    {
        string cadena = "El número " + numero;
        Debug.Log(cadena + ((numero % 2 == 0) ? " es par." : " es impar."));
    }

    private void Basico4(int numero)
    {
        string cadena = "El número " + numero;
        if (numero > 0)
        {
            Debug.Log($"{cadena} es positivo.");
        }
        else if (numero < 0)
        {
            Debug.Log($"{cadena} es negativo.");
        }
        else
        {
            Debug.Log($"{cadena} es cero.");
        }
    }

    private void Basico3(int numero1, int numero2)
    {
        Debug.Log($"{numero1}  y  {numero2} son números {(numero1 == numero2 ? "iguales" : "distintos")} .");
    }

    private void Basico2()
    {
        int[] numeros = { 3, 3, 5, 3, 3 };
        int suma = 0;
        foreach (int i in numeros) suma += i;
        float promedio = suma / 5f;
        Debug.Log($"promedio: {promedio}");
    }

    private void Basico1()
    {
        int numero = 6;
        Debug.Log(numero);
        numero = 10;
        Debug.Log(numero);
    }
}
