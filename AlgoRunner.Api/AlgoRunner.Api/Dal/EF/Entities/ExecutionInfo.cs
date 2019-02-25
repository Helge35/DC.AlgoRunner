namespace AlgoRunner.Api.Dal.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExecutionInfos")]
    public partial class ExecutionInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExecutionInfo()
        {
            AlgoExecutionParams = new HashSet<AlgoExecutionParam>();
        }

        public int ID { get; set; }

        public int? ProjectID { get; set; }

        public int? AlgoID { get; set; }

        public int? ProjectExecutionID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(250)]
        public string ExecutedBy { get; set; }

        [StringLength(1000)]
        public string FileExePath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlgoExecutionParam> AlgoExecutionParams { get; set; }

        public virtual Algorithm Algorithm { get; set; }

        public virtual Project Project { get; set; }
    }
}
