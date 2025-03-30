using UnityEngine;
using UnityEngine.SceneManagement;
public class escenas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void escenass(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
