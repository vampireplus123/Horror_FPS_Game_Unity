using UnityEngine;

public class GameManager : MonoBehaviour
{
  static public GameManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }

}
