using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string Cutscene;

    public void CutsceneCena()
    {
        SceneManager.LoadScene(Cutscene);
    }
}
