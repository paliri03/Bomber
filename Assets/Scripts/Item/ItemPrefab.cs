using UnityEngine;
using UnityEngine.UI;

public class ItemPrefab : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private Button button;
    [SerializeField] private Image icon;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color selectedColor;

    public Button Button => button;
    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void SetDefaultColor()
    {
        bg.color = defaultColor;
    }

    public void SetSelectedColor()
    {
        bg.color = selectedColor;
    }
}
