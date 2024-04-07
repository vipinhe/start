namespace Application.Common.Mappings;

[Mapper]
public static partial class EntityToDtoMapper
{
    public static partial ClientDto MapToDto(this Client item);
}