using UnityEngine;
using UnityEngine.UI;

public class dropdownhandler : MonoBehaviour
{
    public GameObject dropdownPrefab;

    public Transform parentCanvas;

    private Dropdown dropdownInstance;
    private bool isOpen = false;
    private int currentIndex = 0;

    void Start()
    {
        if (dropdownPrefab == null || parentCanvas == null)
        {
            Debug.LogError("Dropdown prefab or parentCanvas is not assigned!");
            return;
        }

        // Instantiate the dropdown
        GameObject spawnedDropdown = Instantiate(dropdownPrefab, parentCanvas);
        dropdownInstance = spawnedDropdown.GetComponent<Dropdown>();
        
        if (dropdownInstance == null)
        {
            Debug.LogError("The prefab does not have a Dropdown component.");
            return;
        }

        currentIndex = dropdownInstance.value;
        HighlightOption(currentIndex);
    }

    void Update()
    {
        if (dropdownInstance == null)
        {
            Debug.Log("nulll");
            return;
        }

        // Open or move down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isOpen)
                OpenDropdown();
            else
                MoveDown();
        }

        // Move up
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOpen)
        {
            MoveUp();
        }

        // Confirm selection
        if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) && isOpen)
        {
            SelectOption();
        }

        // Cancel/close dropdown
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen)
        {
            CloseDropdown();
        }
    }

    void OpenDropdown()
    {
        isOpen = true;
        dropdownInstance.Show();
        HighlightOption(currentIndex);
    }

    void MoveDown()
    {
        currentIndex = (currentIndex + 1) % dropdownInstance.options.Count;
        HighlightOption(currentIndex);
    }

    void MoveUp()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = dropdownInstance.options.Count - 1;

        HighlightOption(currentIndex);
    }

    void HighlightOption(int index)
    {
        // Update visible caption text
        dropdownInstance.captionText.text = dropdownInstance.options[index].text;
    }

    void SelectOption()
    {
        dropdownInstance.value = currentIndex;
        dropdownInstance.Hide();
        dropdownInstance.onValueChanged.Invoke(currentIndex);
        isOpen = false;
    }

    void CloseDropdown()
    {
        dropdownInstance.Hide();
        isOpen = false;
        currentIndex = dropdownInstance.value; // Reset highlight
        HighlightOption(currentIndex);
    }
}
