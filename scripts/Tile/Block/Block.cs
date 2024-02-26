using System;

namespace GameSpace.Tile
{
    public abstract class Block {        
        // Fields
        protected static (byte, byte)[] blockFaceTextureAtlasIndexArray = new (byte, byte)[6];
        protected static (float, float)[] blockFaceTextureAtlasFractionalCoordinate = new (float, float)[6];
        
        // Properties
        public abstract string blockName {get;}

        // Methods
        public (byte, byte) getBlockFaceTextureAtlasIndex(VoxelData.FaceIndex faceIndex) {
            return blockFaceTextureAtlasIndexArray[Convert.ToByte(faceIndex)];
        }

        public (float, float) getBlockFaceTextureAtlasCoordinate(VoxelData.FaceIndex faceIndex) {
            return blockFaceTextureAtlasFractionalCoordinate[Convert.ToByte(faceIndex)];
        }

        protected static (float, float)[] convertToFractionalCoordinateArray((byte, byte)[] IndexArray) {
            (float, float)[] outputArray = new (float, float)[6];
            for (byte i = 0; i < 6; i++) {
                outputArray[i] = 
                    (IndexArray[i].Item1 * BlockData.BASE_BLOCK_TEXTURE_WIDTH,
                    IndexArray[i].Item2 * BlockData.BASE_BLOCK_TEXTURE_HEIGHT);
            }
            return outputArray;
        }
    }
}