using UnityEngine;

namespace ProjectGame
{
    public class GridBehaviour : MonoBehaviour
    {
        public GameObject prefab_grid;

        private int row;
        private int col;
        private GameObject[,] grids;
        private bool gridCreated = false;

        public void initializeGrids()
        {
            createGrids();
            resize();
            gridCreated = true;
        }

        void createGrids()
        {
            grids = new GameObject[row, col];
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    GameObject spawned_object = Instantiate(prefab_grid, new Vector2(y, x), Quaternion.identity);
                    spawned_object.name = "Tile " + x + "-" + y;
                    if ((x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1))
                    {
                        spawned_object.GetComponent<SpriteRenderer>().color = Color.cyan;
                    }
                    grids[x, y] = spawned_object;
                    spawned_object.GetComponent<TileManager>().setRowX(x);
                    spawned_object.GetComponent<TileManager>().setColY(y);
                }

            }
        }

        void resize()
        {
            Camera.main.transform.position = new Vector3(col / 2, row / 2, -5f);
            if (row < 10 && col < 10) { return; }
            float cam_scale;
            if (row >= col)
            {
                cam_scale = row / 10f + 0.1f;
            }
            else
            {
                cam_scale = col / 10f + 0.1f;
            }
            Camera.main.orthographicSize = cam_scale * Camera.main.orthographicSize;
        }

        public void setRow(int x)
        {
            this.row = x;
        }

        public int getRow()
        {
            return this.row;
        }

        public void setCol(int y)
        {
            this.col = y;
        }

        public int getCol()
        {
            return this.col;
        }

        public bool isGridCreated()
        {
            return gridCreated;
        }

        public GameObject[,] getGrids()
        {
            return grids;
        }

    }
}