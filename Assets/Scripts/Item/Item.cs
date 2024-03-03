using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract Sprite InventoryIcon { get; }

    public abstract void Init();

}
