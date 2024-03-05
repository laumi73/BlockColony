using System;

namespace LocalWorld.BlockNS
{
    public abstract class BaseBlock
    {
        // Fields
        protected readonly (byte, byte)[] blockFaceTextureAtlasIndexArray = new (byte, byte)[6];
        protected readonly (float, float)[] blockFaceTextureAtlasCoordinateArray = new (float, float)[6];

        public BaseBlock()
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

        protected abstract (byte, byte) TopFaceAtlasIndex { get; }
        protected abstract (byte, byte) BottomFaceAtlasIndex { get; }
        protected abstract (byte, byte) LeftFaceAtlasIndex { get; }
        protected abstract (byte, byte) RightFaceAtlasIndex { get; }
        protected abstract (byte, byte) FrontFaceAtlasIndex { get; }
        protected abstract (byte, byte) BackFaceAtlasIndex { get; }

        public (byte, byte) TopFaceAtlasUVCoordinate{ get; }
        public (byte, byte) BottomFaceAtlasUVCoordinate{ get; }
        public (byte, byte) LeftFaceAtlasUVCoordinate { get; }
        public (byte, byte) RightFaceAtlasUVCoordinate { get; }
        public (byte, byte) FrontFaceAtlasUVCoordinate { get; }
        public (byte, byte) BackFaceAtlasUVCoordinate { get; }

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