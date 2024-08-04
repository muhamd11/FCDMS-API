using App.Core.Consts.SystemBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.AdditionalModules.FullCodeSequence
{
    [Table($"{nameof(FullCodeSequence)}s", Schema = nameof(EnumDatabaseSchema.AdditionalModules))]
    public class FullCodeSequence
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fullCodeSequenceToken { get; set; }

        public int nextValue { get; set; }
    }
}