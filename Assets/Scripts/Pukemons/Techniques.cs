using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Techniques", menuName = "Puke/Create new move")]
public class Techniques : ScriptableObject
{

    [SerializeField] string names;
    [SerializeField] Pukemonstyles styles;
    [SerializeField] public int Powerpoint;
    [SerializeField] int accuracy;
    [SerializeField] int potency;

    public string Name
    {
        get { return names; }
    }
    public Pukemonstyles Pstyles
    {
        get { return styles; }
    }
    public int Powerpoints
    {
        get { return Powerpoint; }

    }
    public int Accuracy
    {
        get { return accuracy; }
    }
    public int Potency
    {
        get { return potency; }
    }

}
