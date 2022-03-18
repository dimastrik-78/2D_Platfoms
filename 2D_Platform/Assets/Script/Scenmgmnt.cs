using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenmgmnt : MonoBehaviour
{
    public void ChangeLevel(int lvl = 0)
    {
        SceneManager.LoadScene(lvl);
    }
}
