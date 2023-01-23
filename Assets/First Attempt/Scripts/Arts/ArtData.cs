using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class ArtData
{
    [SerializeField] private Image icon;

    [SerializeField] private string artName; 
    
    [SerializeField] private float maxArtTime;

    [SerializeField] private ArtData replaceArt;

    public abstract void Start();
    public abstract bool Update();

    public Image Icon => icon;

    public string ArtName => artName;
    public float MaxArtTime => maxArtTime;

    public ArtData ReplaceArt => replaceArt;
}
