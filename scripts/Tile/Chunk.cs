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

        public BlockData[,,] blockArray = new BlockData[ChunkResources.CHUNK_WIDTH, ChunkResources.CHUNK_HEIGHT, ChunkResources.CHUNK_WIDTH];


        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            base._Ready();
            _material = GD.Load<StandardMaterial3D>(BlockResources.BASE_BLOCK_ATLAS_FILEPATH);

            PopulateChunk(blockArray);
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            base._Process(delta);
        }

        private void PopulateChunk(BlockData[,,] blockArray)
        {
            _meshInstance3D = new MeshInstance3D();
            _arrayMesh = new();

            _surfaceTool.Begin(Mesh.PrimitiveType.Triangles);
            _surfaceTool.SetMaterial(_material);
            _surfaceTool.GenerateNormals(false);

            for (byte y = 0; y < 2; y++) {
                for (byte x = 0; x < 2; x++) {
                    for (byte z = 0; z < 2; z++) {
                        DrawBlock(new Vector3(x, y, z));
                    }
                }
            }
            _surfaceTool.Commit(_arrayMesh);

            _meshInstance3D.Mesh = _arrayMesh;
            _meshInstance3D.CreateTrimeshCollision();

            AddChild(_meshInstance3D);
        }

        private void DrawBlock(Vector3 position)
        {
            DrawFaces(position);
        }

        private void DrawFaces(Vector3 position)
        {
            DrawFaceByDirection(position, Convert.ToByte(VoxelResources.FaceIndex.TOP), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelResources.FaceIndex.BOTTOM), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelResources.FaceIndex.LEFT), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelResources.FaceIndex.RIGHT), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelResources.FaceIndex.FRONT), 0, 0);
            DrawFaceByDirection(position, Convert.ToByte(VoxelResources.FaceIndex.BACK), 0, 0);
        }

        private void DrawFaceByDirection(Vector3 position, byte directionIndex, int atlasXIndex, int atlasYIndex)
        {
            Vector3[] vertices = new Vector3[] {
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 0]] + position,
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 1]] + position,
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 2]] + position,
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 3]] + position
            };

            Vector2 uvVertex_bottomRight = new((atlasXIndex + 1) * BlockResources.BASE_BLOCK_TEXTURE_WIDTH, atlasYIndex * BlockResources.BASE_BLOCK_ATLAS_HEIGHT);
            Vector2 uvVertex_topRight =
                new((atlasXIndex + 1) * BlockResources.BASE_BLOCK_TEXTURE_WIDTH,
                (atlasYIndex + 1) * BlockResources.BASE_BLOCK_TEXTURE_HEIGHT);
            Vector2 uvVertex_bottomLeft = new(atlasXIndex * BlockResources.BASE_BLOCK_ATLAS_WIDTH, atlasYIndex * BlockResources.BASE_BLOCK_ATLAS_HEIGHT);
            Vector2 uvVertex_topLeft = new(atlasXIndex * BlockResources.BASE_BLOCK_ATLAS_WIDTH, (atlasYIndex + 1) * BlockResources.BASE_BLOCK_TEXTURE_HEIGHT);

            Vector3[] triangle = new Vector3[] { vertices[0], vertices[1], vertices[2] };
            Vector2[] uv = new Vector2[] { uvVertex_bottomRight, uvVertex_topRight, uvVertex_bottomLeft };
            _surfaceTool.AddTriangleFan(triangle, uv);

            triangle = new Vector3[] { vertices[2], vertices[1], vertices[3] };
            uv = new Vector2[] { uvVertex_bottomLeft, uvVertex_topRight, uvVertex_topLeft };
            _surfaceTool.AddTriangleFan(triangle, uv);
        }
    }
}
