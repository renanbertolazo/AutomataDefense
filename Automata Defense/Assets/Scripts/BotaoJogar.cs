using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BotaoJogar : MonoBehaviour {
    public void CarregaCena() {
        SceneManager.LoadScene("Jogo");
    }
}
