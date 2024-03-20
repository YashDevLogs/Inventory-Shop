using System.Collections.Generic;
using UnityEngine;

public class SlotPoolManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public int poolSize = 20;
    private Queue<GameObject> slotPool = new Queue<GameObject>();

    private void Start()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject slotObject = Instantiate(slotPrefab, transform);
            slotObject.SetActive(false);
            slotPool.Enqueue(slotObject);
        }
    }

    public GameObject GetSlotFromPool()
    {
        if (slotPool.Count == 0)
        {
            Debug.LogWarning("Slot pool exhausted. Consider increasing pool size.");
            return null;
        }

        GameObject slotObject = slotPool.Dequeue();
        slotObject.SetActive(true);
        return slotObject;
    }

    public void ReturnSlotToPool(GameObject slotObject)
    {
        slotObject.SetActive(false);
        slotPool.Enqueue(slotObject);
    }
}
