using System;

namespace GameSpace.Tile
{
    public sealed class Grass : Block {
        static Grass() {
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.TOP)] = (5, 0);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.BOTTOM)] = (5, 1);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.LEFT)] = (5, 1);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.RIGHT)] = (5, 1);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.FRONT)] = (5, 1);
            blockFaceTextureAtlasIndexArray[Convert.ToByte(VoxelData.FaceIndex.BACK)] = (5, 1);

            blockFaceTextureAtlasFractionalCoordinate = convertToFractionalCoordinateArray(blockFaceTextureAtlasIndexArray);
        }

        public override string blockName {get {return "Grass";}}
    }
}