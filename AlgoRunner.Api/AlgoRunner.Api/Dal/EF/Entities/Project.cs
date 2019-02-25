namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            ExecutionInfos = new HashSet<ExecutionInfo>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Desc { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public bool? IsFavorite { get; set; }

        public DateTime? LastExecutionDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExecutionInfo> ExecutionInfos { get; set; }
    }
}
