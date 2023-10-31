using Godot;
using System;
using System.Collections.Generic;

public partial class Chunk : Node3D
{
	List<Vector3> vertices = new();
	List<int> triangles = new();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 0]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 1]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 2]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 2]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 1]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 3]]);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
