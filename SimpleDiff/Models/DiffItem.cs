using System.ComponentModel.DataAnnotations;

namespace SimpleDiff.Models
{
    public sealed class DiffItem
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Key]
        [Required]
        [EnumDataType(typeof(DiffType))]
        public DiffType Type { get; set; } 
        [Required]
        [StringLength(500)]
        public string Value { get; set; } = string.Empty;
    }

    public enum DiffType
    {
        Left = 0,
        Right = 1
    }
}

