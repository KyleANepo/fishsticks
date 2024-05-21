using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum Direction { Up, Down, Left, Right };

public class Inputs : MonoBehaviour
{
    [SerializeField] Direction direction;

    Inputs(Direction dir)
    {
        direction = dir;
    }

    public Direction getDirection()
    {
        return direction;
    }

    public void Remove()
    {
        Destroy(this.gameObject);
    }
}
