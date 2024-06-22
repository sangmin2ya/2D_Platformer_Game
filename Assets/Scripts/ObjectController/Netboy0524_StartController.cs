using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Netboy0524_StartController : Netboy0524_DestroyableObject
{
    protected override void Destroy()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Game");
    }
}
