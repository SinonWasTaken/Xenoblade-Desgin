using System;
using UnityEngine;

[Serializable]
public class ArtResistance
{
    [SerializeField] private ArtData resistantToArt;
    [SerializeField] private float resistantValue;

    public ArtResistance(ArtData resistantToArt, float resistantValue)
    {
        this.resistantToArt = resistantToArt;
        this.resistantValue = resistantValue;
    }

    public ArtData ResistantToArt => resistantToArt;

    public float ResistantValue => resistantValue;
}
