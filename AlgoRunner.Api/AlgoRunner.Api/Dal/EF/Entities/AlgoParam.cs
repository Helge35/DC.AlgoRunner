namespace AlgoRunner.Api.Dal.EF.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;

    public partial class AlgoParam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }        
        [StringLength(1000)]
        public string Value { get; set; }

        [NotMapped]
        public KeyValuePair<int, string> Type
        {
            get
            {
                var ser = new JsonSerializer();
                var jr = new JsonTextReader(new StringReader(TypeJSON));

                return ser.Deserialize<KeyValuePair<int, string>>(jr);
            }
            set
            {
                var ser = new JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                TypeJSON = sw.ToString();
            }
        }

        [Column("Type")]
        public string TypeJSON { get; set; }

        [NotMapped]
        public List<string> Range
        {
            get
            {
                if (RangeJSON == null)
                    return new List<string>();

                var ser = new JsonSerializer();
                var jr = new JsonTextReader(new StringReader(RangeJSON));

                return ser.Deserialize<List<string>>(jr);
            }
            set
            {
                var ser = new JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                RangeJSON = sw.ToString();
            }
        }

        [Column("Range")]
        public string RangeJSON { get; set; }
    }
}
