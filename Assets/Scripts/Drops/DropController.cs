using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public List<Drop> dropTable;

    public GameObject GetRandomItem()
    {
        // CDF stands for Cumulative Distribution Function Array
        List<float> CDFArray = new List<float>();
        float total = 0;

        foreach (Drop drop in dropTable)
        {
            total += drop.weight;
            CDFArray.Add(total);
        }

        float randomNumber = Random.Range(0, total);

        int selectedIndex = System.Array.BinarySearch(CDFArray.ToArray(), randomNumber);
        if (selectedIndex < 0)
        {
            selectedIndex = ~selectedIndex;
        }
        return dropTable[selectedIndex].itemDrop;
    }
}
