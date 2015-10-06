using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    static Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public static void Player1Win()
    {
        anim.SetTrigger("Player1Win");
    }
    public static void Player2Win()
    {
        anim.SetTrigger("Player2Win");
    }
}
