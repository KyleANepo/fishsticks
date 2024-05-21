using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputGrid : MonoBehaviour
{
    List<Inputs> inputs = new List<Inputs>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateGrid(Fish fish)
    {
        foreach (Inputs input in fish.inputs)
        {
            inputs.Add(Instantiate(input, new Vector3(transform.position.x + (2 * inputs.Count), transform.position.y, 0), transform.rotation, transform));
        }
    }

    public void removeInput()
    {
        inputs[0].Remove();
        inputs.RemoveAt(0);
    }
    
    public void clearInputs()
    {
        foreach (Inputs input in  inputs)
        {
            input.Remove();
        }
        inputs.Clear();
    }
}
