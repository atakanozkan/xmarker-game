using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame
{
    public class TileManager : MonoBehaviour
    {
        public GameObject cover;
        public GameObject mark_cover;

        private List<GameObject> neighbors_list;
        private MarkController markController;

        private bool hasMark = false;

        private int colY;
        private int rowX;

        private void Awake()
        {
            markController = GameObject.FindObjectOfType<MarkController>();
        }

        private void Update()
        {
            triggerNeighbors();
        }

        void triggerNeighbors()
        {
            if (hasMark)
            {
                if (markController.checkNeighbors(rowX, colY) == null)
                {
                    return;
                }
                this.setNeighbors(markController.checkNeighbors(rowX, colY));
            }
        }

        private void OnMouseEnter()
        {
            if (!hasMark)
            {
                cover.SetActive(true);
            }
        }

        private void OnMouseExit()
        {
            cover.SetActive(false);
        }

        private void OnMouseDown()
        {
            hasMark = true;
            mark_cover.SetActive(true);
            markController.list_of_marked.Add(this.gameObject);
        }

        public void setRowX(int x)
        {
            this.rowX = x;
        }

        public int getRowX()
        {
            return rowX;
        }

        public void setColY(int y)
        {
            this.colY = y;
        }

        public int getColY()
        {
            return colY;
        }

        public void setMark(bool mark)
        {
            this.hasMark = mark;
        }

        public bool getMark()
        {
            return hasMark;
        }
        public List<GameObject> getNeighbors()
        {
            return neighbors_list;
        }
        public void setNeighbors(List<GameObject> list)
        {
            this.neighbors_list = list;
        }
    }
}