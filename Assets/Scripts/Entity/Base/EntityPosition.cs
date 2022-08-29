using UnityEngine;

public class EntityPosition : MonoBehaviour
{
    public enum EntityPositionIndicator
    {
        Front, 
        Left,
        Right,
        Back
    }

    [SerializeField]
    private EntityPositionIndicator _position;

    public EntityPositionIndicator Position => _position;
}
