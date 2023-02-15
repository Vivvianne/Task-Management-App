using TaskManagement.Domain.Models.Options;

namespace TaskManagement.Domain.Mappings.Options
{
    /// <summary>
    /// Represents the option mapping
    /// </summary>
    public class OptionMap : TaskManagementEntityTypeConfiguration<Option>
    {
        public OptionMap()
        {
            this.ToTable(nameof(Option));

            this.HasKey(option => option.Id);

            this.HasIndex(option => option.EntityGuid).IsUnique();
        }
    }
}
