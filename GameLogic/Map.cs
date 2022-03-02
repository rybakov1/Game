namespace Game.Logic
{
	public class Map
	{
		public TerrainTile[,] TerrinTiles;
		public ObjectTile[,] ObjectTiles;
		private int _width;
		private int _height;

		public int Height
		{
			get => _height; 
			set => _height = value;
		}
		public int Width
		{
			get => _width;
			init => _width = value;
		}

		public Map(int width, int height)
		{
			_width = width;
			_height = height;

			TerrinTiles = new TerrainTile[width, height];
			TerrinTiles.Initialize();
			ObjectTiles = new ObjectTile[width, height];
			ObjectTiles.Initialize();
		}

		/// <summary>
		/// Fill map for test
		/// </summary>
		public void Fill(TerrainTile tile)
		{
			for (int x = 0; x < Width; x++)
				for (int y = 0; y < Height; y++)
					TerrinTiles[x, y] = tile;
		}
	}
}
