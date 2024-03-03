using System;

namespace LocalWorld.BlockNS
{
    public sealed class Stone : Block
    {
        // Fields
        private static readonly (byte, byte)[] blockFaceTextureAtlasIndexArray = new (byte, byte)[6];
        private static readonly (float, float)[] blockFaceTextureAtlasCoordinateArray = new (float, float)[6];

        // Singleton setup
        private static readonly Lazy<Stone> lazy = new(() => new Stone());
        public static Stone Instance { get { return lazy.Value; } }

        static Stone()
        {
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.TOP)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.BOTTOM)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.LEFT)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.RIGHT)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.FRONT)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.BACK)] = (2, 5);

            blockFaceTextureAtlasCoordinateArray = ConvertToFractionalCoordinateArray(blockFaceTextureAtlasIndexArray);
        }

        public override string BlockName { get { return "Stone"; } }
        public override short BlockID { get { return 1; } }
        public override (byte, byte)[] BlockFaceTextureAtlasIndexes { get { return blockFaceTextureAtlasIndexArray; } }
        public override (float, float)[] BlockFaceTextureAtlasCoordinates { get { return blockFaceTextureAtlasCoordinateArray; } }
    }
}