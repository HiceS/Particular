﻿using System;
using System.Threading.Tasks;
using SharpMesh.Data;

namespace SharpMesh.Decomposer.Voxel
{
    /// <summary>
    /// This should voxelize a given Mesh(float) ideally.
    /// </summary>
    public sealed class VoxelDecomposer : Decomposer<float>
    {

        /// <summary>
        /// Options supplied to the decomposition.
        /// </summary>
        public readonly VoxelOptions Options;

        /// <summary>
        /// Simple constructor that takes in the mesh to be operated on.
        /// Operation is started on construction.
        /// It would be super awesome to be able to register callbacks when this is done in other code.
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="options"></param>
        public VoxelDecomposer(Mesh<float> mesh, VoxelOptions options) : base(mesh)
        {
            Options = options;
        }

        /// <summary>
        /// Internal method for computing the mesh with multiple operations.
        /// Or just 1 it really doesn't matter much.
        /// </summary>
        /// <returns></returns>
        private static async Task<DecomposerResult> Compute(Mesh<float> mesh, VoxelOptions options)
        {
            mesh.Vertices[0].X += 1.0f;

            // dummy await call for now.
            await Task.Delay(0);
            
            // This is where you can split your algorithm into multiple threads or queues and then you can chose to rejoin them at the end with an await.
            // I think that would cause an awaitable object to exist.
            
            return new DecomposerResult();
        }

        public override Task<DecomposerResult> RunAsync()
        {
            // This is what actually runs the Task assigned.
            // If you just want to do CPU bound work you can call an await directly after this to ensure the work was complete.
            Result = Task.Run(() => Compute(Mesh, Options), CancellationTokenSource.Token);

            return Result;
        }

        public override DecomposerResult Run()
        {
            // This would mean it's not implemented yet.
            throw new NotImplementedException();
        }
    }
}