using Godot;
using System;
using LocalWorld.BlockNS;

namespace LocalWorld
{
    [Tool]
    public partial class Chunk : Node3D
    {
        private ArrayMesh _arrayMesh;
        private MeshInstance3D _meshInstance3D;
        private SurfaceTool _surfaceTool = new();
        private Material _material;

        public BlockStruct[,,] blockArray = new BlockStruct[ChunkResources.CHUNK_WIDTH, ChunkResources.CHUNK_HEIGHT, ChunkResources.CHUNK_WIDTH];


        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            base._Ready();
            _material = GD.Load<StandardMaterial3D>(BlockResources.BASE_BLOCK_ATLAS_FILEPATH);
            GenerateChunk();
            DrawChunk();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            base._Process(delta);
        }

        private void GenerateChunk() {
            for (byte y = 0; y < ChunkResources.CHUNK_HEIGHT; y++) {
                for (byte x = 0; x < ChunkResources.CHUNK_WIDTH; x++) {
                    for (byte z = 0; z < ChunkResources.CHUNK_WIDTH; z++) {
                        if (y < 40) {
                            blockArray[x, y, z] = new BlockStruct{blockID = ((ushort)BlockResources.BlockDictionary.Stone)};
                        }
                        else if (y < 63) {
                            blockArray[x, y, z] = new BlockStruct{blockID = ((ushort)BlockResources.BlockDictionary.Dirt)};
                        }
                        else if (y == 64) {
                            blockArray[x, y, z] = new BlockStruct{blockID = ((ushort)BlockResources.BlockDictionary.Grass)};
                        }
                    }
                }
            }
        }

        private void DrawChunk()
        {
            _meshInstance3D = new MeshInstance3D();
            _meshInstance3D.Name = "ChunkMesh";
            _arrayMesh = new();

            _surfaceTool.Begin(Mesh.PrimitiveType.Triangles);
            _surfaceTool.SetMaterial(_material);
            _surfaceTool.GenerateNormals(false);

            GD.Print(BlockResources.blockList);
            for (byte y = 0; y < ChunkResources.CHUNK_HEIGHT; y++) {
                for (byte x = 0; x < ChunkResources.CHUNK_WIDTH; x++) {
                    for (byte z = 0; z < ChunkResources.CHUNK_WIDTH; z++) {
                        DrawBlock(new Vector3(x, y, z), BlockResources.blockList[blockArray[x, y, z].blockID]);
                    }
                }
            }
            _surfaceTool.Commit(_arrayMesh);

            _meshInstance3D.Mesh = _arrayMesh;
            _meshInstance3D.CreateTrimeshCollision();

            AddChild(_meshInstance3D);
        }

        private void DrawBlock(Vector3 position, BaseBlock block)
        {
            DrawFaceByDirection(position, VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.TOP], block.TopFaceAtlasUVCoordinate);
            DrawFaceByDirection(position, VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.BOTTOM], block.BottomFaceAtlasUVCoordinate);
            DrawFaceByDirection(position, VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.LEFT], block.LeftFaceAtlasUVCoordinate);
            DrawFaceByDirection(position, VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.RIGHT], block.RightFaceAtlasUVCoordinate);
            DrawFaceByDirection(position, VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.FRONT], block.FrontFaceAtlasUVCoordinate);
            DrawFaceByDirection(position, VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.BACK], block.BackFaceAtlasUVCoordinate);
        }

        private void DrawFaceByDirection(Vector3 position, byte directionIndex, (float, float) atlasUVCoordinate)
        {
            Vector3[] vertices = new Vector3[] {
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 0]] + position,
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 1]] + position,
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 2]] + position,
                VoxelResources.voxelVertices[VoxelResources.voxelTriangles[directionIndex, 3]] + position
            };

            Vector2 uvVertex_bottomRight = new((atlasUVCoordinate.Item1 + 1) * BlockResources.BASE_BLOCK_TEXTURE_WIDTH, atlasUVCoordinate.Item2 * BlockResources.BASE_BLOCK_ATLAS_HEIGHT);
            Vector2 uvVertex_topRight =
                new((atlasUVCoordinate.Item1 + 1) * BlockResources.BASE_BLOCK_TEXTURE_WIDTH,
                (atlasUVCoordinate.Item2 + 1) * BlockResources.BASE_BLOCK_TEXTURE_HEIGHT);
            Vector2 uvVertex_bottomLeft = new(atlasUVCoordinate.Item1 * BlockResources.BASE_BLOCK_ATLAS_WIDTH, atlasUVCoordinate.Item2 * BlockResources.BASE_BLOCK_ATLAS_HEIGHT);
            Vector2 uvVertex_topLeft = new(atlasUVCoordinate.Item1 * BlockResources.BASE_BLOCK_ATLAS_WIDTH, (atlasUVCoordinate.Item2 + 1) * BlockResources.BASE_BLOCK_TEXTURE_HEIGHT);

            Vector3[] triangle = new Vector3[] { vertices[0], vertices[1], vertices[2] };
            Vector2[] uv = new Vector2[] { uvVertex_bottomRight, uvVertex_topRight, uvVertex_bottomLeft };
            _surfaceTool.AddTriangleFan(triangle, uv);

            triangle = new Vector3[] { vertices[2], vertices[1], vertices[3] };
            uv = new Vector2[] { uvVertex_bottomLeft, uvVertex_topRight, uvVertex_topLeft };
            _surfaceTool.AddTriangleFan(triangle, uv);
        }
    }
}
