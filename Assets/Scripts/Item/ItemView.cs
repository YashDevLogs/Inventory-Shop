using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject itemScriptableObject;
    [SerializeField] private ItemController controller;

    [SerializeField] private GameObject SlotPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }
}
