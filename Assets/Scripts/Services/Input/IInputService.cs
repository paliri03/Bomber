using System;
using UnityEngine;

public interface IInputService
{
    public event Action<Vector2> OnHold;
    public event Action<Vector2> OnTap;
}
