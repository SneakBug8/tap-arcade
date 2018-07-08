using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    Image image;
    Color color = Color.green;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.color = Color.Lerp(image.color, color, 0.1f);

        if (image.color == color)
        {
            if (color == Color.green)
            {
                color = Color.magenta;
            }
            else
            {
                color = Color.green;
            }
        }
    }
}