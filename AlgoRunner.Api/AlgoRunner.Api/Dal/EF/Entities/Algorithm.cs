namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Algorithm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Algorithm()
        {
            ExecutionInfos = new HashSet<ExecutionInfo>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Desc { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(1000)]
        public string FileServerPath { get; set; }

        public int? AlgResultTypeID { get; set; }

        public virtual AlgResultType AlgResultType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExecutionInfo> ExecutionInfos { get; set; }
    }
}
