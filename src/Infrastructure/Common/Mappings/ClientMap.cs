namespace Infrastructure.Common.Mappings;

internal class ClientMap : IEntityTypeConfiguration<Client>
{
    internal static List<Client>? Clients { get; set; }

    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        if (Clients is not null)
        {
            builder.HasData(Clients);
        }
    }
}