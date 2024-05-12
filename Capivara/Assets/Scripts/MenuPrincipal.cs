using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string Cutscene;
    [SerializeField] private string Logon;

    public void CutsceneCena()
    {
        SceneManager.LoadScene(Cutscene);
    }
    
    public void LogonCena()
    {
        SceneManager.LoadScene(Logon);
    }
}
