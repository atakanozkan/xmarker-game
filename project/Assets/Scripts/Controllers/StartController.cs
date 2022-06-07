using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace ProjectGame
{
    public class StartController : MonoBehaviour
    {
        public Text input_field;
        public GameObject initial_canvas;
        public GameObject game_canvas;

        public void storeAndPlay()
        {
            int input;
            String s = input_field.text.ToString().Trim();
            try
            {
                input = Int32.Parse(s);
            }
            catch (FormatException)
            {
                Debug.Log("Unable to format!");
                return;
            }

            if (input == 0) { return; }

            var gridManager = GameObject.FindWithTag("GridManager");
            if (gridManager == null) { return; }

            GridBehaviour behaviour = gridManager.GetComponent<GridBehaviour>();
            behaviour.setRow(input);
            behaviour.setCol(input);
            behaviour.initializeGrids();
            initial_canvas.SetActive(false);
            game_canvas.SetActive(true);
        }

        public void backToMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}