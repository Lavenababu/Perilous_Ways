using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void Locked()
    {
        gameObject.SetActive(false);
    }

    public void Unlocked()
    {
        gameObject.SetActive(true);
    }
}
