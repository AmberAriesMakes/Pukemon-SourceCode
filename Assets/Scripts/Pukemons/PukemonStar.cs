using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pukemon", menuName = "Pukemon/Create Pukemon")]
public class PukemonStar : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] string names;
    [SerializeField] Sprite front;
   
    [SerializeField] Sprite back;
    [SerializeField] Pukemonstyles style;

    [SerializeField] int maxHp;
    [SerializeField] int speed;
    [SerializeField] int defence;
    [SerializeField] int attack;
    [SerializeField] List<LearnableMove>learnableMoves;

    public string Name
    {
        get { return names; }
    }

    

    public Sprite Front 
    {
        get { return front; }
    }
    public Sprite Back
    {
        get { return back; }
    }
    public int MaxHp
    {
        get { return maxHp; }
    }
    public int Speed
    {
        get { return speed; }
    }
    public List<LearnableMove>LearnableMoves
    {
        get { return learnableMoves; }
    }
    public int Defence
    {
        get { return defence; }
    }
    public int Attack
    {
        get { return attack; }
    }

    
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] public Techniques TechBase;
    [SerializeField] public int lvl;
   
    public Techniques Base
    {
        get { return TechBase; }
    }
    public int LVL
    {
        get { return lvl; }
    }
}


public enum Pukemonstyles
{
    bland,
    fire,
    water,
    grass,
}
