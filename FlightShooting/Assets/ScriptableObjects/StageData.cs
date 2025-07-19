using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Objects/StageData")]
public class StageData : ScriptableObject
{
    public Vector2 LimitMin => _limitMin;
    public Vector2 LimitMax => _limitMax;

    [SerializeField] private Vector2 _limitMin;
    [SerializeField] private Vector2 _limitMax;
}
