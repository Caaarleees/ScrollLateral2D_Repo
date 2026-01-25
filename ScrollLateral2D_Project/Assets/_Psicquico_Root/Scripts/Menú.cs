using UnityEngine;
using UnityEngine.SceneManagement;
public class Menú : MonoBehaviour
{
public void Jugar()
    {
        SceneManager.LoadScene("LVL_DiegoTest");
    }
  public  void Salir()
    {
        Application.Quit();
    }
}
