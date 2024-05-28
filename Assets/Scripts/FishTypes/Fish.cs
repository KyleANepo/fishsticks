using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Fish : MonoBehaviour
{
    public List<Inputs> inputs; // List of inputs to catch the fish.
    public int score;

    public string type;
    public Sprite sprite;
    public string description;

    [SerializeField] float speed;

    private void Start()
    {
        // start effects
    }

    private void Update()
    {
        //Swim(); dont do this in fish lol
    }

    public Inputs getInput()
    {
        return inputs[0];
    }

    // update sprite and such eventually
    public void removeInput()
    {
        inputs.RemoveAt(0);
    }

    public void Swim()
    {
        float speedMod = (speed + (GameManager.Instance.combo / 4)) / GameManager.Instance.bait; // update speed to go faster with combo
        // Debug.Log(speedMod);
        transform.Translate(Vector3.right * speedMod * Time.deltaTime);
    }

    // for player successful input (instantiate special effect) [this can be modified for any special case fish]
    public void Catch()
    {
        // catch effects
        Destroy(this.gameObject);
    }

    // if fish gets away without player doing proper inputs
    public void Vanish()
    {
        // vanish effects
        Destroy(this.gameObject);
    }
}