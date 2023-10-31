using Godot;

public static class VoxelData
{
	public static readonly Vector3[] voxelVertices = new Vector3[8] {
		new(0f, 0f, 0f),
		new(1f, 0f, 0f),
		new(1f, 1f, 0f),
		new(0f, 1f, 0f),
		new(0f, 0f, 1f),
		new(1f, 0f, 1f),
		new(1f, 1f, 1f),
		new(0f, 1f, 1f)
	};

	public static readonly int[,] voxelTriangles = new int[1,4] {
		{3, 7, 2, 6} // Top face
	};
}
