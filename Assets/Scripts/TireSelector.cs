using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSelector : MonoBehaviour
{
    public int currentTireCarIndex;
    public GameObject[] tires;

    void Start()
    {
        currentTireCarIndex = PlayerPrefs.GetInt("SelectedTire");
        foreach (GameObject tire in tires)
            tire.SetActive(false);

        tires[currentTireCarIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
