using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private GameObject Fadeout;

    [SerializeField]
    private Transform ui;

    public void selection(int select)
    {
        ui = GameObject.FindGameObjectWithTag("canva").GetComponent<Transform>();
        Instantiate(Fadeout, transform.position, Quaternion.identity,ui);

        if(select == 1)
        {
            StartCoroutine(reload());
        }
        else
        {
            StartCoroutine(ExitApl());

        }

    }

    public IEnumerator reload()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main");
    }

    public IEnumerator ExitApl()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }

}
