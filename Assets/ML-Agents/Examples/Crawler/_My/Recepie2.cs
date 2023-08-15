using System;
using UnityEngine;

[HideInInspector]
public enum IngredientUnit2 { Spoon, Cup, Bowl, Piece }

// Custom serializable class
[Serializable]
public class Ingredient2
{
    public string name;
    public int amount = 1;
    public IngredientUnit2 unit;
}

public class Recepie2 : MonoBehaviour
{
    public Ingredient2 potionResult;
    public Ingredient2[] potionIngredients;
}
