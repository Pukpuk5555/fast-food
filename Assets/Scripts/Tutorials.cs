using UnityEngine;

public class Tutorials : MonoBehaviour
{
    [SerializeField] private GameObject tut1;
    [SerializeField] private GameObject tut2;
    [SerializeField] private GameObject tut3;

    public void NextToTut2()
    {
        tut2.SetActive(true);
        tut1.SetActive(false);
    }

    public void NextToTut3()
    {
        tut3.SetActive(true);
        tut2.SetActive(false);
    }

    public void BackToTut1()
    {
        tut2.SetActive(false);
        tut1.SetActive(true);
    }

    public void BackToTut2()
    {
        tut3.SetActive(false);
        tut2.SetActive(true);
    }
}
