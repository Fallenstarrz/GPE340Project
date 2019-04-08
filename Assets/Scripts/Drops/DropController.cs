using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public List<Drop> dropTable;

    /// <summary>
    /// This function looks at the drop table and picks an item
    /// based off the weights the object has set up in the inspector.
    /// Higher weight = more likely
    /// </summary>
    /// <returns>Drop gameObject from dropTable</returns>
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
