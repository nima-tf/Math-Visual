using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Internal;

public class ItemGenerator : MonoBehaviour
{
    [System.ComponentModel.DefaultValue(Recipe.None)]
    private enum Recipe
    {
        Iron,
        Copper, 
        Coal,
        None
    }
    
    [Header("Object Setup")]
    [SerializeField] private TextMeshProUGUI  outputDisplayTextRef;
    [SerializeField] private TextMeshProUGUI  recipeDisplayTextRef;
    
    [Header("Device Settings")]
    [SerializeField] private bool isActive = true;
    [SerializeField] private float itemsPerSecond;
    [SerializeField] private uint maxStorageCap = 20;
    [SerializeField] private uint outputStorage = 0;
    [SerializeField] private Recipe recipe = new Recipe();
    
    private float timer = 0;
    private bool recipeSelected = false;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        recipeSelected = (recipe != Recipe.None);
        
        recipeDisplayTextRef.text = recipe.ToString();

        if (isActive && recipeSelected)
        {
            GenerateResource();
        }
        else
        {
            ResetItemGenerator();
        }
    }
    
    

    private void GenerateResource()
    {
        if (outputStorage >= maxStorageCap) return;
        timer += Time.deltaTime;
        if (timer < 1.0 / itemsPerSecond) return;
        outputStorage += 1;
        timer = 0;
        outputDisplayTextRef.text = outputStorage.ToString();
    }
    
    
    private void ResetItemGenerator()
    {
        timer = 0;
    }
}
