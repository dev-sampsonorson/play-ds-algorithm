using System;

namespace PlayDsAlgorithm.Core
{
    internal class SolutionDesc
    {
        public int Id { get; private set; }

        public Type SolutionType { get; private set; }

        public SolutionDesc(int id, Type solutionType)
        {
            Id = id;
            SolutionType = solutionType;
        }
    }
}
