using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame
{
    public class MarkController : MonoBehaviour
    {
        public GridBehaviour behaviour;
        public ScoreController scoreController;
        public List<GameObject> list_of_marked;

        private void Update()
        {
            if (list_of_marked.Count>= 3)
            {
                explodeNeighbors();
            }
            updateMarkedList();
        }

        public List<GameObject> checkNeighbors(int x, int y)
        {
            List<GameObject> list = new List<GameObject>();
            if (!behaviour.isGridCreated()) { return null; }
            for (int row = x - 1; row <= x + 1; row++) {
                if (row < 0 || row >= behaviour.getRow()) { continue; }
                for (int col = y - 1; col <= y + 1; col++) {
                    if (col < 0 || col >= behaviour.getCol()) { continue; }
                    if (row == x && col == y) { continue; }
                    TileManager tileManager = behaviour.getGrids()[row, col].GetComponent<TileManager>();
                    if (tileManager.getMark())
                    {
                        list.Add(tileManager
                            .gameObject);
                    }
                }
            }
            
            return list;
        }
        public void explodeNeighbors()
        {
            
            foreach(GameObject marked in list_of_marked)
            {
                TileManager manager = marked.GetComponent<TileManager>();
                if (manager.getNeighbors() == null) { continue; }
                if (manager.getNeighbors().Count < 2) { continue; }
                foreach (GameObject neighbor in manager.getNeighbors())
                {
                    TileManager neighbor_manager = neighbor.GetComponent<TileManager>();
                    neighbor_manager.setMark(false);
                    neighbor_manager.mark_cover.SetActive(false);
                }
                int bonus = manager.getNeighbors().Count + 1;
                scoreController.IncrementScore(bonus);
                manager.setNeighbors(new List<GameObject>());
                manager.setMark(false);
                manager.mark_cover.SetActive(false);
            }
        }
        private void updateMarkedList()
        {
            List<GameObject> temp_list = new List<GameObject>();
            foreach(GameObject obj in list_of_marked)
            {
                TileManager manager = obj.GetComponent<TileManager>();
                if (manager.getMark())
                {
                    temp_list.Add(obj);
                }
            }
            list_of_marked = temp_list;
        }

    }
}

