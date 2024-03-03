using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel", menuName = "ScriptableObjects/PlayerModel")]
public class PlayerModel : ScriptableObject
{
    [SerializeField] private List<Item> availableItems;
    [SerializeField] private float itemSpawnHeight;
    public List<Item> AvailableItems => availableItems;
    public float ItemSpawnHeight => itemSpawnHeight;
}