using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    [SerializeField] bool playerunit;
    [SerializeField] PukemonStar _Base;
    [SerializeField] int level;


    public PukemonProg Pukemon { get; set; }
    public void Setup()
    {

        Pukemon = new PukemonProg(_Base, level);
        if (playerunit)
            GetComponent<Image>().sprite = Pukemon.Base.Front;
        else
            GetComponent<Image>().sprite = Pukemon.Base.Front;
    }
}
