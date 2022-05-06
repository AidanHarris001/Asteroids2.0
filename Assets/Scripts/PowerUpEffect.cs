using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : MonoBehaviour
{
    public abstract void Apply(GameObject target);
}
