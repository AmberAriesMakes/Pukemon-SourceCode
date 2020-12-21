using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PukemonProg 
{
    [SerializeField] PukemonStar _Base;
    [SerializeField] int level;

    public PukemonStar Base
    {
        get
        {
            return _Base;
        }
    }
    public int Level
    {
        get
        {
            return level;
        }
    }

    public int Health { get; set; }
    
    public List<MoveManager> Moves { get; set; }


    public PukemonProg(PukemonStar Bbase, int Level)
    {
        _Base = Bbase;
        Health = TotalHp;
        Moves = new List<MoveManager>();
        foreach (var move in Base.LearnableMoves)
        {
            if (move.LVL <= Level)
            {
                Moves.Add(new MoveManager(move.Base));

            }
            if (Moves.Count >= 4)
                break;
        }
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 1; }
    }
    public int Defence
    {
        get { return Mathf.FloorToInt((Base.Defence * Level) / 100f) + 1; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 1; }
    }
    public int TotalHp
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 10; }
    }
    public bool Damage(MoveManager move, PukemonProg attacker)
    {
        float modifers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250;
        float d = a * move.Base.Potency * ((float)attacker.Attack / Defence) + 2;
        int damage = Mathf.FloorToInt(d * modifers);

        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            return true;
        }
        return false;
    }
    public MoveManager RandomAttack()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
