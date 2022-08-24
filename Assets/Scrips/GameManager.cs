using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action EventDead;
 
    void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnEnable()
    {
        EventDead += Dead;
    }
    private void OnDisable()
    {
        EventDead -= Dead;
    }
}
