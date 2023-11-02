using Godot;
using System;
using System.Collections.Generic;

public partial class Chunk : Node3D
{
	List<Vector3> vertices = new();
	List<int> triangles = new();

	private Mesh _mesh;
	private MeshInstance3D _meshInstance3D;
	private SurfaceTool _surfaceTool = new();



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (_meshInstance3D != null) {
			_meshInstance3D.CallDeferred("queue_free");
			_meshInstance3D = null;
		}
		_mesh = new();
		_meshInstance3D = new();


		DrawFace();
	}

	internal void DrawFace() {
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 0]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 1]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 2]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 2]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 1]]);
		vertices.Add(VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 3]]);

		/*
		vertices = new List<Vector3>(6) {
			VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 0]],
			VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 1]],
			VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 2]],
			VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 2]],
			VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 1]],
			VoxelData.voxelVertices[VoxelData.voxelTriangles[0, 3]]
		};
		*/
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
