using System;

namespace LocalWorld.BlockNS
{
    public abstract class Block
    {
        // Fields
        public static readonly Block[] blockList = new Block[short.MaxValue];
        protected readonly (byte, byte)[] blockFaceTextureAtlasIndexArray = new (byte, byte)[6];
        protected readonly (float, float)[] blockFaceTextureAtlasCoordinateArray = new (float, float)[6];

        static Block()
        {
            blockList[Grass.Instance.BlockID] = Grass.Instance;
        }

        public Block()
        {
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.TOP)] = TopFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.BOTTOM)] = BottomFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.LEFT)] = LeftFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.RIGHT)] = RightFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.FRONT)] = FrontFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelResources.FaceIndex.BACK)] = BackFaceAtlasIndex;

            blockFaceTextureAtlasCoordinateArray = ConvertToFractionalCoordinateArray(blockFaceTextureAtlasIndexArray);
        }

        // Properties
        public abstract BlockResources.BlockDictionary BlockEnum { get; }
        public string BlockName { get { return BlockEnum.ToString(); } }
        public short BlockID { get { return (short)BlockEnum; } }
        public abstract (byte, byte) TopFaceAtlasIndex { get; }
        public abstract (byte, byte) BottomFaceAtlasIndex { get; }
        public abstract (byte, byte) LeftFaceAtlasIndex { get; }
        public abstract (byte, byte) RightFaceAtlasIndex { get; }
        public abstract (byte, byte) FrontFaceAtlasIndex { get; }
        public abstract (byte, byte) BackFaceAtlasIndex { get; }
        public (float, float)[] BlockFaceTextureAtlasCoordinates { get { return blockFaceTextureAtlasCoordinateArray; } }

        // Methods
        protected static (float, float)[] ConvertToFractionalCoordinateArray((byte, byte)[] IndexArray)
        {
            (float, float)[] outputArray = new (float, float)[6];
            for (byte i = 0; i < 6; i++)
            {
                outputArray[i] =
                    (IndexArray[i].Item1 * BlockResources.BASE_BLOCK_TEXTURE_WIDTH,
                    IndexArray[i].Item2 * BlockResources.BASE_BLOCK_TEXTURE_HEIGHT);
            }
            return outputArray;
        }
    }
}