using System;

namespace GameSpace.Tile
{
    public sealed class Stone : Block {
        static Stone() {
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.TOP)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.BOTTOM)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.LEFT)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.RIGHT)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.FRONT)] = (2, 5);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.BACK)] = (2, 5);

            blockFaceTextureAtlasFractionalCoordinate = convertToFractionalCoordinateArray(blockFaceTextureAtlasIndexArray);
        }

        public override string blockName {get {return "Stone";}}
    }
}