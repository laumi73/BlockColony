using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameSpace
{
    public partial class Chunk : Node3D
    {
        private ArrayMesh _arrayMesh;
        private MeshInstance3D _meshInstance3D;
        private SurfaceTool _surfaceTool = new();

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _meshInstance3D = new MeshInstance3D();
            _arrayMesh = new();

            _surfaceTool.Begin(Mesh.PrimitiveType.Triangles);
            DrawFaces();
            _surfaceTool.GenerateNormals(false);
            _surfaceTool.Commit(_arrayMesh);

            _meshInstance3D.Mesh = _arrayMesh;

            AddChild(_meshInstance3D);
        }

        internal void DrawFaces()
        {
            Vector3[] vertices = new Vector3[] {
                VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 0]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 1]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 2]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 3]]
            };

            Vector3[] triangle1 = new Vector3[] { vertices[0], vertices[1], vertices[2] };
            Vector3[] triangle2 = new Vector3[] { vertices[2], vertices[1], vertices[3] };

            _surfaceTool.AddTriangleFan(triangle1);
            _surfaceTool.AddTriangleFan(triangle2);
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
        }
    }
}
