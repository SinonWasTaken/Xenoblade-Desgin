using UnityEngine;

[System.Serializable]
public class Art : ArtData
{
    [SerializeField] private float currentArtTime;
    
    public override void Start()
    {
        currentArtTime = MaxArtTime;
    }

    public override bool Update()
    {
        currentArtTime -= Time.deltaTime;

        currentArtTime = Mathf.Clamp(currentArtTime, 0, MaxArtTime);
        
        return currentArtTime == 0;
    }
}
