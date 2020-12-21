using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager 
{
    public Techniques Base { get; set; }
    public int  Powerpoint { get; set; }
   

    public MoveManager(Techniques Bbase)
    {

        Base = Bbase;
        Powerpoint = Bbase.Powerpoint;
        
    }
}
