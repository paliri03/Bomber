using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private Button restartButton;

    public event Action OnRestartButtonClicked;

    public void Init()
    {
        restartButton.onClick.AddListener(() => OnRestartButtonClicked.Invoke());
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
        gameOverWindow.SetActive(false);
    }

    public void OpenGameOverWindow()
    {
        inventory.SetActive(false);
        gameOverWindow.SetActive(true);
    }
}
