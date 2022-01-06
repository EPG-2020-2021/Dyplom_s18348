using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IStat
{
    void Increase(string statKey);

    void Decrease(string statKey);

}
