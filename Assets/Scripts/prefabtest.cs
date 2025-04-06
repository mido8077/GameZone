using UnityEngine;
using System.Collections.Generic;
using GameSystem;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;  // The prefab you want to extract objects from
    private List<GameObject> allObjectsInPrefab = new List<GameObject>();

    public void Start()
    {
        Debug.Log("PrefabTest script started.");

    }

    public List<GameObject> getObjectsFromPrefab(string path)
    {
        // Load the prefab from Resources folder (Make sure the prefab is inside the Resources folder)
        prefab = Resources.Load<GameObject>(path);

        if (prefab == null)
        {
            Debug.LogError("Prefab could not be loaded! Ensure it is inside a 'Resources' folder.");
            return null;
        }

        // Instantiate the prefab in the scene temporarily
        GameObject prefabInstance = Instantiate(prefab);

        // Clear previous data
        allObjectsInPrefab.Clear();

        foreach (Transform child in prefabInstance.transform)
        {
            allObjectsInPrefab.Add(child.gameObject);  // Add each child GameObject to the list
        }
        return allObjectsInPrefab;  

    }

    // Recursive method to collect all child GameObjects of a parent

}
