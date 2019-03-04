using System.Collections.Generic;

namespace AlgoRunner.Api.Entities
{
    public class ResultCategoryEntity
    {
        public string Label { get; set; }
        public List<PointEntity> Data { get; set; }
    }
}
