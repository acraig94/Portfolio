using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class Grid
    {
        private int gridWidth; // number of cells wide
        private int cellWidth; // width of cells

        private Cell[,] cells; // 2d array of cell

        private DrawManager dm;

        public Grid(DrawManager dm, ILaplacianFactory algorithm, IBrushFactory brush, double feedRate, double killRate, double diffA, double diffB, int gridWidth, int cellWidth)
        {
            this.dm = dm;
            // Set variales
            this.gridWidth = gridWidth;
            this.cellWidth = cellWidth;
            // Create cells
            cells = CreateCells(dm, algorithm, brush, feedRate, killRate, diffA, diffB);
            // Set cells neighbours
            SetCellsNeighbours();
            // Seed a small portion of cells
            SeedArea();
        }
        // Tells each cell to call its ComputeNewConcentrations method
        public void ComputeConcentrations()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    cells[j, i].ComputeNewConcentrations();
                }
            }
        }
        // Tells each cell to call its UpdateCell method
        public void UpdateCells()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    cells[j, i].UpdateCell();
                }
            }
        }
        // Tells each cell to call its Draw method 
        public void DrawCells()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    cells[j, i].Draw();
                }
            }
            dm.DrawToScreen();
        }
        // Used to create a grid of cells
        public Cell[,] CreateCells(DrawManager dm, ILaplacianFactory algorithm, IBrushFactory brush, double feedRate, double killRate, double diffA, double diffB)
        {
            Cell[,] cellArray = new Cell[gridWidth, gridWidth];
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    cellArray[j, i] = new Cell(dm, brush, new Point(j, i), cellWidth, algorithm, diffA, diffB, feedRate, killRate);
                }
            }
            return cellArray;
        }
        // Sets the neighbours of each cell
        public void SetCellsNeighbours()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    cells[j, i].NeighbourCells = IdentifyNeighbours(cells[j, i]);
                }
            }
        }
        // Finds all neighbours for an individual cell
        public Cell[] IdentifyNeighbours(Cell c)   
        {
            Cell[] neighbours = new Cell[8];
            Point[] neighboursPos =
            {
                new Point { X = c.Position.X-1, Y = c.Position.Y-1}, // Top Left
                new Point { X = c.Position.X, Y = c.Position.Y-1},   // Top
                new Point { X = c.Position.X+1, Y = c.Position.Y-1}, // Top Right
                new Point { X = c.Position.X-1, Y = c.Position.Y},   // Left
                new Point { X = c.Position.X+1, Y = c.Position.Y},   // Right
                new Point { X = c.Position.X-1, Y = c.Position.Y+1}, // Bottom Left
                new Point { X = c.Position.X, Y = c.Position.Y+1},   // Bottom
                new Point { X = c.Position.X+1, Y = c.Position.Y+1} // Bottom Right
            };
            // fix edge rows & columns
            neighboursPos = CorrectNeighboursPosition(neighboursPos);
            // give neighbours array correct cells
            for (int i = 0; i < neighbours.Length; i++)
            {
                neighbours[i] = cells[neighboursPos[i].X, neighboursPos[i].Y];
            }

            return neighbours;
        }
        // Used to check if neighbour position is out off bounds and corrects it if so
        public Point[] CorrectNeighboursPosition(Point[] n)
        {
            Point[] neighboursPos = n;
            for (int i = 0; i < neighboursPos.Length; i++)
            {
                if (neighboursPos[i].X < 0)
                {
                    neighboursPos[i].X = gridWidth - 1;
                }
                else if (neighboursPos[i].X > gridWidth - 1)
                {
                    neighboursPos[i].X = 0;
                }
                if (neighboursPos[i].Y < 0)
                {
                    neighboursPos[i].Y = gridWidth - 1;
                }
                else if (neighboursPos[i].Y > gridWidth - 1)
                {
                    neighboursPos[i].Y = 0;
                }
            }
            return neighboursPos;
        }
        // Seeds the middle cell and its neighbours - so 9 cells in total
        public void SeedArea()
        {
            int half = gridWidth / 2;
            cells[half - 1, half - 1].MakeSeed();
            cells[half, half - 1].MakeSeed();
            cells[half + 1, half - 1].MakeSeed();
            cells[half - 1, half].MakeSeed();
            cells[half, half].MakeSeed();
            cells[half + 1, half].MakeSeed();
            cells[half - 1, half + 1].MakeSeed();
            cells[half, half + 1].MakeSeed();
            cells[half + 1, half + 1].MakeSeed();
        }





    }
}
