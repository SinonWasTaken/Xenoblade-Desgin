using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ArtController))]
public class Entity : MonoBehaviour
{
    [Header("Base Entity Details")]
    [SerializeField] private string entityName;

    public string EntityName => entityName;
}
