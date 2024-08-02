using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.Core.Models.AdditionalModules.FullCodeSequence
{
    public class FullCodeSequence
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fullCodeSequenceToken { get; set; }
        public int nextValue { get; set; }
    }
}
