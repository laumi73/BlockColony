using System;

namespace LocalWorld.BlockNS
{
    public sealed class Grass : Block
    {
        // Fields
        private const short BLOCK_ID = 2;
        private const string BLOCK_NAME = "Grass";

        // Faces
        private static readonly (byte, byte) _topFaceIndex = (5, 0);
        private static readonly (byte, byte) _bottomFaceIndex = (5, 1);
        private static readonly (byte, byte) _leftFaceIndex = _bottomFaceIndex;
        private static readonly (byte, byte) _rightFaceIndex = _bottomFaceIndex;
        private static readonly (byte, byte) _frontFaceIndex = _bottomFaceIndex;
        private static readonly (byte, byte) _backFaceIndex = _bottomFaceIndex;


        private static readonly (byte, byte)[] blockFaceTextureAtlasIndexArray = new (byte, byte)[6];
        private static readonly (float, float)[] blockFaceTextureAtlasCoordinateArray = new (float, float)[6];

        // Singleton setup
        private static readonly Lazy<Grass> lazy = new(() => new Grass());
        public static Grass Instance { get { return lazy.Value; } }

        static Grass()
        {
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.TOP)] = _topFaceIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.BOTTOM)] = _bottomFaceIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.LEFT)] = _leftFaceIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.RIGHT)] = _rightFaceIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.FRONT)] = _frontFaceIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.BACK)] = _backFaceIndex;

            blockFaceTextureAtlasCoordinateArray = ConvertToFractionalCoordinateArray(blockFaceTextureAtlasIndexArray);
        }

        public override string BlockName { get { return BLOCK_NAME; } }
        public override short BlockID { get { return BLOCK_ID; } }
        public override (byte, byte)[] BlockFaceTextureAtlasIndexes{get {return blockFaceTextureAtlasIndexArray;}}
        public override (float, float)[] BlockFaceTextureAtlasCoordinates{get {return blockFaceTextureAtlasCoordinateArray;}}
    }
}