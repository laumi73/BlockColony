using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LocalWorld
{
    public partial class Chunk : Node3D
    {
        private ArrayMesh _arrayMesh;
        private MeshInstance3D _meshInstance3D;
        private SurfaceTool _surfaceTool = new();
        private Material _material;

        public short[,,] blockArray = new short[ChunkData.CHUNK_WIDTH, ChunkData.CHUNK_HEIGHT, ChunkData.CHUNK_WIDTH];


        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            base._Ready();
            _material = GD.Load<StandardMaterial3D>(BlockData.BASE_BLOCK_ATLAS_FILEPATH);
            
            blockArray = PopulateChunk();
            DrawBlock(new Vector3(0f, 0f, 0f));
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            base._Process(delta);
        }

        private short[,,] PopulateChunk() {
            return new short[ChunkData.CHUNK_WIDTH, ChunkData.CHUNK_HEIGHT, ChunkData.CHUNK_WIDTH];
        }

        private void DrawBlock(Vector3 position) {
            _meshInstance3D = new MeshInstance3D();
            _arrayMesh = new();

            _surfaceTool.Begin(Mesh.PrimitiveType.Triangles);
            _surfaceTool.SetMaterial(_material);
            _surfaceTool.GenerateNormals(false);
            DrawFaces(position);
            _surfaceTool.Commit(_arrayMesh);

            _meshInstance3D.Mesh = _arrayMesh;
            _meshInstance3D.CreateTrimeshCollision();

            AddChild(_meshInstance3D);
        }

        private void DrawFaces(Vector3 position)
        {
            DrawFaceByDirection(position, Convert.ToByte(VoxelData.FaceIndex.TOP), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelData.FaceIndex.BOTTOM), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelData.FaceIndex.LEFT), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelData.FaceIndex.RIGHT), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelData.FaceIndex.FRONT), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelData.FaceIndex.BACK), 0, 0);
        }

        private void DrawFaceByDirection(Vector3 position, byte directionIndex, int atlasXIndex, int atlasYIndex) {
            Vector3[] vertices = new Vector3[] {
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 0]] + position,
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 1]] + position,
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 2]] + position,
                VoxelData.voxelVertices[VoxelData.voxelTriangles[directionIndex, 3]] + position
            };

            Vector2 uvVertex_bottomRight = new((atlasXIndex + 1) * BlockData.BASE_BLOCK_TEXTURE_WIDTH, atlasYIndex * BlockData.BASE_BLOCK_ATLAS_HEIGHT);
            Vector2 uvVertex_topRight = 
                new((atlasXIndex + 1) * BlockData.BASE_BLOCK_TEXTURE_WIDTH,
                (atlasYIndex + 1) * BlockData.BASE_BLOCK_TEXTURE_HEIGHT);
            Vector2 uvVertex_bottomLeft = new(atlasXIndex * BlockData.BASE_BLOCK_ATLAS_WIDTH, atlasYIndex * BlockData.BASE_BLOCK_ATLAS_HEIGHT);
            Vector2 uvVertex_topLeft = new(atlasXIndex * BlockData.BASE_BLOCK_ATLAS_WIDTH, (atlasYIndex + 1) * BlockData.BASE_BLOCK_TEXTURE_HEIGHT);

            Vector3[] triangle = new Vector3[] { vertices[0], vertices[1], vertices[2] };
            Vector2[] uv = new Vector2[] {uvVertex_bottomRight, uvVertex_topRight, uvVertex_bottomLeft};
            _surfaceTool.AddTriangleFan(triangle, uv);

            triangle = new Vector3[] { vertices[2], vertices[1], vertices[3] };
            uv = new Vector2[] {uvVertex_bottomLeft, uvVertex_topRight, uvVertex_topLeft};
            _surfaceTool.AddTriangleFan(triangle, uv);
        }
    }
}
