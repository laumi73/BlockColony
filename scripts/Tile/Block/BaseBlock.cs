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
            blockFaceTextureAtlasIndexArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.TOP]] = TopFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.BOTTOM]] = BottomFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.LEFT]] = LeftFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.RIGHT]] = RightFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.FRONT]] = FrontFaceAtlasIndex;
            blockFaceTextureAtlasIndexArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.BACK]] = BackFaceAtlasIndex;

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

        public (float, float) TopFaceAtlasUVCoordinate{ get {return blockFaceTextureAtlasCoordinateArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.TOP]];} }
        public (float, float) BottomFaceAtlasUVCoordinate{ get{return blockFaceTextureAtlasCoordinateArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.BOTTOM]];} }
        public (float, float) LeftFaceAtlasUVCoordinate { get{return blockFaceTextureAtlasCoordinateArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.LEFT]];} }
        public (float, float) RightFaceAtlasUVCoordinate { get{return blockFaceTextureAtlasCoordinateArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.RIGHT]];} }
        public (float, float) FrontFaceAtlasUVCoordinate { get{return blockFaceTextureAtlasCoordinateArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.FRONT]];} }
        public (float, float) BackFaceAtlasUVCoordinate { get{return blockFaceTextureAtlasCoordinateArray[VoxelResources.FaceIndexDictionary[VoxelResources.FaceIndex.BACK]];} }

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