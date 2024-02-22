using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GameSpace
{
    public partial class Chunk : Node3D
    {
        private ArrayMesh _arrayMesh;
        private MeshInstance3D _meshInstance3D;
        private SurfaceTool _surfaceTool = new();
        private Material _material;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            base._Ready();
            _material = GD.Load<StandardMaterial3D>(BlockData.BASE_BLOCK_ATLAS_FILEPATH);
            
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
            _surfaceTool.SetMaterial(_material);
            _surfaceTool.GenerateNormals(false);
            DrawFaces();
            _surfaceTool.Commit(_arrayMesh);

            _meshInstance3D.Mesh = _arrayMesh;
            _meshInstance3D.CreateTrimeshCollision();

            AddChild(_meshInstance3D);
        }

        private void DrawFaces()
        {
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.TOP), 0, 0);
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.BOTTOM), 0, 0);
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.LEFT), 0, 0);
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.RIGHT), 0, 0);
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.FRONT), 0, 0);
            DrawFaceByDirection(Convert.ToByte(VoxelData.FaceIndex.BACK), 0, 0);
        }

        private void DrawFaceByDirection(byte directionIndex, int atlasXIndex, int atlasYIndex) {
            Vector3[] vertices = new Vector3[] {
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 0]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 1]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 2]],
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 3]]
            };

            Vector2 uvVertex_bottomRight = new(BlockData.BASE_BLOCK_TEXTURE_WIDTH, 0f);
            Vector2 uvVertex_topRight = new(BlockData.BASE_BLOCK_TEXTURE_WIDTH, BlockData.BASE_BLOCK_TEXTURE_HEIGHT);
            Vector2 uvVertex_bottomLeft = new(0f, 0f);
            Vector2 uvVertex_topLeft = new(0f, BlockData.BASE_BLOCK_TEXTURE_HEIGHT);

            Vector3[] triangle = new Vector3[] { vertices[0], vertices[1], vertices[2] };
            Vector2[] uv = new Vector2[] {uvVertex_bottomRight, uvVertex_topRight, uvVertex_bottomLeft};
            _surfaceTool.AddTriangleFan(triangle, uv);

            triangle = new Vector3[] { vertices[2], vertices[1], vertices[3] };
            uv = new Vector2[] {uvVertex_bottomLeft, uvVertex_topRight, uvVertex_topLeft};
            _surfaceTool.AddTriangleFan(triangle, uv);
        }
    }
}
