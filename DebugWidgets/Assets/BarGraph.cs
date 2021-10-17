using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

/// <summary>
/// Controls a BarGraph widget
/// BarGraph widgets are GameObjects that have one of these as a component, as well as an Image (like a sprite but different)
/// and a text field.  There's a prefab for the widget in the Resources folder.
/// </summary>
public class BarGraph : MonoBehaviour
{
    /// <summary>
    /// The Image component of the bar part of the widget
    /// An Image is like a SpriteRenderer but different
    /// This is the literal bar that grows and shrinks
    /// </summary>
    public Image BarImage;
    /// <summary>
    /// This is the transform of the GameObject containing BarImage.
    /// Changing its scale changes the size of the bar.
    /// </summary>
    public RectTransform BarTransform;

    /// <summary>
    /// The text component of the widget
    /// Changing its .text field changes what's displayed.
    /// </summary>
    public TMP_Text Text;

    /// <summary>
    /// The minimum allowable value for this widget
    /// Anything less will make the widget display in red
    /// </summary>
    public float Min;
    /// <summary>
    /// The maximum allowable value for this widget
    /// Anything larger will make the widget display in red.
    /// </summary>
    public float Max = 1;

    // True if we're allowing negative values for this bar graph
    private bool signedDisplay;
    
    // Start is called before the first frame update
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        
        Text.text = name;
        
        // This sets width to the width of the widget on screen
        var rectTransform = (RectTransform)transform;
        var width = rectTransform.sizeDelta.x * rectTransform.localScale.x;

        //displaying signed number when the value is negative
        if(Min < 0 || Max <0){
            signedDisplay = true;
            Vector3 pos = BarTransform.localPosition;
            BarTransform.localPosition = new Vector3(width /2,pos.y,pos.z);
        }
        
    }

    /// <summary>
    /// Change the value displayed in the bar graph
    /// This should both change the bar itself and also the text displayed below it.
    /// </summary>
    /// <param name="value">Value to display</param>
    public void SetReading(float value)
    {


        Text.text = name + ":" + value;
        
        var color = Color.green;

        if(value < Min ){
            value = Min;
            color = Color.red;
        } else if (value > Max){
            value = Max;
            color = Color.red;
        } else if (value < 0){
            color = Color.blue;
        }
    
        SetWidthPercent(value, color);
        
    }

    /// <summary>
    /// Set the bar to value percent of its maximum width
    /// value = 0 means its zero-width
    /// value = 1 means it's maximum width
    /// value = -1 (signed display) means it's maximum width in the other direction
    /// </summary>
    /// <param name="value">Percentage of the maxim</param>
    /// <param name="c"></param>
    public void SetWidthPercent(float value, Color c)
    {

        BarImage.color = c;
        Vector3 pos = BarTransform.localScale;
        if(signedDisplay){
            value = value/2;
        }

        if (value < 0 && signedDisplay) {
            value = -(value / Min);
        } else if (value >0 && signedDisplay){
            value = value / Max ;
        }

        BarTransform.localScale = new Vector3(value,pos.y,pos.z);
    }

    #region Dynamic creation
    /// <summary>
    /// Table of all the bar graphs made using the Find method below.
    /// </summary>
    // ReSharper disable once ArrangeObjectCreationWhenTypeEvident
    private static readonly Dictionary<string, BarGraph> BarGraphTable = new Dictionary<string, BarGraph>();

    /// <summary>
    /// Find the bar graph stored with the specified name and return it.
    /// If there isn't one, then make one in the specified position and give it the specified
    /// min and max values.  Then store it in the table so we can find it in the future.
    /// </summary>
    /// <param name="name">Name of the bar graph</param>
    /// <param name="position">Where to put it on the screen if it hasn't been made already</param>
    /// <param name="min">Minimum value for it to display</param>
    /// <param name="max">Maximum value for it to display</param>
    /// <returns></returns>
    public static BarGraph Find(string name, Vector2 position, float min, float max)
    {
      
        if(BarGraphTable.ContainsKey(name)){
            return BarGraphTable[name];
        }
        //
        // Otherwise, we need to make a new one
        //

        // The UI system requires that all UI widgets be inside of the GameObject that has the Canvas component.
        // So find the canvas component
        var canvas = FindObjectOfType<Canvas>();

        // Instantiate(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform)
        // Set its position to position and its rotation to the magic value Quaternion.identity, which means
        // "don't rotate it".
        var go = Instantiate(Prefab,position,Quaternion.identity,canvas.transform);

        go.name = name;

        var bgComponent = go.GetComponent<BarGraph>();

        bgComponent.Min = min;
        bgComponent.Max = max;
        // Add the BarGraph component to the table
        BarGraphTable[name] = bgComponent;

        // Return the BarGraph component
        return bgComponent;
    }

    // This is where we stash the prefab once we've loaded it so we don't have to keep loading it.
    private static GameObject prefab;

    // Return the prefab for bar graphs
    private static GameObject Prefab
    {
        get
        {
            prefab = Resources.Load<GameObject>("BarGraph");


            // Now that prefab isn't null, we can return it.
            return prefab;
        }
    }
    #endregion
}
