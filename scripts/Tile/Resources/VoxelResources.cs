using Godot;

namespace LocalWorld
{
    public static class VoxelResources
    {
        public static readonly Vector3[] voxelVertices = new Vector3[8] {
            new(0f, 0f, 0f), //0
			new(1f, 0f, 0f), //1
			new(1f, 1f, 0f), //2
			new(0f, 1f, 0f), //3
			new(0f, 0f, 1f), //4
			new(1f, 0f, 1f), //5
			new(1f, 1f, 1f), //6
			new(0f, 1f, 1f)  //7
		};

        public static readonly byte[,] voxelTriangles = new byte[6, 4] {
            {2, 6, 3, 7}, // Top face
			{0, 4, 1, 5}, // Bottom face
			{0, 3, 4, 7}, // Left face
			{5, 6, 1, 2}, // Right face
			{4, 7, 5, 6}, // Front face
			{1, 2, 0, 3}  // Back face
		};

        public static readonly Vector2[] voxelUvs = new Vector2[4] {
            new(1f, 0f),
            new(1f, 1f),
            new(0f, 0f),
            new(0f, 1f)
        };

        public enum FaceIndex
        {
            TOP = 0,
            BOTTOM = 1,
            LEFT = 2,
            RIGHT = 3,
            FRONT = 4,
            BACK = 5
        }
    }
}
