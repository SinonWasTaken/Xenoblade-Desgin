using UnityEngine;

public class ArtController : MonoBehaviour
{
    [SerializeField] private Art currentArt;

    [SerializeField] private ArtResistance[] resistantValues;
    
    public void AddArt(Art art)
    {
        if (currentArt == null)
        {
            if (art.ArtName == "Break")
            {
                currentArt = art;
                currentArt.Start();
            }
        }
        else
        {
            if (art.ReplaceArt == currentArt)
            {
                currentArt = art;
                currentArt.Start();
            }
        }
    }

    private void Update()
    {
        if (currentArt != null)
        {
            if (currentArt.Update())
            {
                //Remove any effects
                currentArt = null;
            }
        }
    }
}
