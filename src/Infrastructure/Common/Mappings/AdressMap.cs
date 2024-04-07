namespace Infrastructure.Common.Mappings;

internal class AddressMap : IEntityTypeConfiguration<Address>
{
    internal static List<Address>? Addresses { get; set; }

    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Client)
            .WithMany()
            .HasForeignKey(x => x.ClientId);
        
        if (Addresses is not null)
        {
            builder.HasData(Addresses);
        }
    }
}