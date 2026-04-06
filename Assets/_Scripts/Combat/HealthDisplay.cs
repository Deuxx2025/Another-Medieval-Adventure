using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab; 
    [SerializeField] private Transform heartsContainer; 
    [SerializeField] private Sprite Hearts;

    private List<Image> _hearts = new List<Image>();

    public void Initialize(int maxHealth)
    {
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
        }
        _hearts.Clear();

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject h = Instantiate(heartPrefab, heartsContainer);
            _hearts.Add(h.GetComponent<Image>());
        } 
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].gameObject.SetActive(i < currentHealth);
        }
    }
}
