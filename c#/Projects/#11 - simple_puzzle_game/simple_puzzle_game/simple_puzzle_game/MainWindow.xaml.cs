using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace simple_puzzle_game
{
    public partial class MainWindow : Window
    {
        private readonly List<Image> _gridTiles;  // Store all grid tiles
        private readonly Random _random;         // For generating random positions

        private bool _isDragging = false;  // To track if the user is currently dragging
        private Image _startTile;          // The tile where the user started dragging (red1 or red2)
        private List<Image> _visitedTiles; // Keep track of the tiles the user has visited


        public MainWindow()
        {
            InitializeComponent();

            // Initialize the random number generator
            _random = new Random();

            // Store references to all grid tiles (for easier swapping)
            _gridTiles = new List<Image> { grid2, grid3, grid4, grid5, grid6, grid7, grid8 };
            _visitedTiles = new List<Image>();
        }

        // Function to handle button click event
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Get valid positions for red1 and red2 that are not adjacent
            var validPositions = GetValidRedTilePositions();

            // Move red1 to a new position and swap the image at that position
            MoveRedTile(red1, validPositions[0]);

            // Move red2 to another valid position and swap the image at that position
            MoveRedTile(red2, validPositions[1]);
        }

        // Function to get valid positions for red tiles, ensuring no adjacency
        private List<int> GetValidRedTilePositions()
        {
            // List of possible positions (excluding adjacent and overlapping positions)
            var positions = new List<int> { 1, 3, 5, 7 };

            // Shuffle the positions to get random valid positions
            for (int i = positions.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (positions[i], positions[j]) = (positions[j], positions[i]);
            }

            // Return the first two positions as the valid ones
            return positions.GetRange(0, 2);
        }

        // Function to move a red tile to a new position and swap the image with the grid tile
        private void MoveRedTile(Image redTile, int newPosition)
        {
            // Store the current position of the red tile (row and column)
            int oldRow = Grid.GetRow(redTile);
            int oldColumn = Grid.GetColumn(redTile);

            // Get the target grid tile based on the new position
            Image gridTile = _gridTiles[newPosition - 1];  // Positions are 1-based

            // Swap the positions of the red tile and the grid tile
            Grid.SetRow(redTile, Grid.GetRow(gridTile));
            Grid.SetColumn(redTile, Grid.GetColumn(gridTile));
            Grid.SetRow(gridTile, oldRow);
            Grid.SetColumn(gridTile, oldColumn);
        }
        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var tile = sender as Image;

            // Only allow dragging if the clicked tile is red1 or red2
            if (tile == red1 || tile == red2)
            {
                _isDragging = true;
                _startTile = tile;
                _visitedTiles.Clear(); // Clear visited tiles before starting new drag

                // Change the red tile image to its activated version
                tile.Source = new BitmapImage(new Uri("./Assets/red_activated.png", UriKind.Relative));
            }
        }

        private void Tile_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var tile = sender as Image;

                // Ensure the tile being dragged over is part of the grid and not red1/red2
                if (!_visitedTiles.Contains(tile) && tile != red1 && tile != red2)
                {
                    _visitedTiles.Add(tile); // Track visited tiles to avoid updating multiple times

                    // Check the direction of movement
                    if (_visitedTiles.Count > 1)
                    {
                        var previousTile = _visitedTiles[_visitedTiles.Count - 2];
                        UpdateTileImage(tile, previousTile);  // Update the current tile with the appropriate image
                    }
                    else
                    {
                        // First grid tile being activated
                        tile.Source = new BitmapImage(new Uri("./Assets/red_grid_line_straight.png", UriKind.Relative));
                    }
                }
            }
        }
        private void UpdateTileImage(Image currentTile, Image previousTile)
        {
            // Determine the direction of movement (horizontal, vertical, or turn)
            int currentRow = Grid.GetRow(currentTile);
            int currentColumn = Grid.GetColumn(currentTile);
            int previousRow = Grid.GetRow(previousTile);
            int previousColumn = Grid.GetColumn(previousTile);

            // Vertical movement
            if (currentColumn == previousColumn)
            {
                currentTile.Source = new BitmapImage(new Uri("./Assets/red_grid_line_straight.png", UriKind.Relative));
            }
            // Horizontal movement
            else if (currentRow == previousRow)
            {
                currentTile.Source = new BitmapImage(new Uri("./Assets/red_grid_line_straight.png", UriKind.Relative));
            }
            // Corner movement (turn)
            else
            {
                currentTile.Source = new BitmapImage(new Uri("./Assets/red_grid_line_bend.png", UriKind.Relative));
            }
        }


        private void Tile_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
        }
    }
}
