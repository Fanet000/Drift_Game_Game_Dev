using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    //Layout
    public HorizontalLayoutGroup root;
    public List<VerticalLayoutGroup> sections;
    public RectOffset padding;
    public float spacing;
    public bool showLayout;

    //Color
    public Color primary, secondary, accent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnValidate()
    {
        root.padding = padding;
        root.spacing = spacing;

        Color primaryCol = Color.clear;
        Color secondaryCol = Color.clear;
        Color accentCol = Color.clear;

        foreach (VerticalLayoutGroup item in sections)
        {
            item.padding = new(0, 0, 0, 0);
            item.spacing = spacing;

            if (showLayout)
            {
                primaryCol = primary;
                secondaryCol = secondary;
                accentCol = accent;
            }

            int count = 0;

            foreach (RectTransform cell in item.transform)
            {
                if (cell.TryGetComponent<Image>(out Image gridCell))
                {
                    gridCell.color = secondaryCol;
                    cell.gameObject.name = "Cell" + count;
                    count++;
                }

                else
                {
                    Debug.Log("Image not found");
                }

            }
        }

        Image bg = GetComponent<Image>();
        bg.color = primaryCol;

        var elements = GetComponentsInChildren<ViewElement>();
        foreach (ViewElement icon in elements) 
        {

            if (icon.TryGetComponent<Image>(out var iconImage))
            {
               if (!iconImage.TryGetComponent<ViewElement>(out var element))
               {
                    iconImage.color = accentCol;
               }
            }
        }
    }
}
