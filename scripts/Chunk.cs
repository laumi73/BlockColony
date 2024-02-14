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
            base._Ready();
            DrawBlock();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            base._Process(delta);
        }

        private void DrawBlock() {
            _meshInstance3D = new MeshInstance3D();
            _arrayMesh = new();

            _surfaceTool.Begin(Mesh.PrimitiveType.Triangles);
            DrawFaces();
            _surfaceTool.GenerateNormals(false);
            _surfaceTool.Commit(_arrayMesh);


            _meshInstance3D.Mesh = _arrayMesh;
            _meshInstance3D.CreateTrimeshCollision();

            AddChild(_meshInstance3D);
        }

        private void DrawFaces()
        {
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.TOP));
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.BOTTOM));
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.LEFT));
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.RIGHT));
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.FRONT));
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.BACK));
        }

        private void DrawFaceByDirection(byte directionIndex) {
            Vector3[] vertices = new Vector3[] {
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 0]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 1]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 2]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 3]]
            };

            Vector3[] triangle1 = new Vector3[] { vertices[0], vertices[1], vertices[2] };
            Vector3[] triangle2 = new Vector3[] { vertices[2], vertices[1], vertices[3] };

            _surfaceTool.AddTriangleFan(triangle1);
            _surfaceTool.AddTriangleFan(triangle2);
        }
    }
}
