using Hid.Checkpoint.Common.Models.Email;
using Hid.Checkpoint.Common.ViewModels;
using Hid.Checkpoint.Domain.Models;
using Mapster;

namespace Hid.Checkpoint.Business;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmailItem, EmailViewModel>()
            .Map(dst => dst.To,
                src => src.To.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());

        config.NewConfig<EmailViewModel, EmailItem>()
            .Map(dst => dst.To, src => string.Join(',', src.To));

        config.NewConfig<PropertyMetadata, PropertyMetadataViewModel>()
            .Map(dst => dst.InterfaceId, src => src.Property.InterfaceId)
            .Map(dst => dst.Name, src => src.Property.Name)
            .Map(dst => dst.FullName, src => src.Property.FullName)
            .Map(dst => dst.DisplayName, src => src.Property.DisplayName)
            .Map(dst => dst.Required, src => src.Required)
            .Map(dst => dst.Visible, src => src.Visible)
            .Map(dst => dst.ColumnDefaultVisibility, src => src.ColumnDefaultVisibility);

        

        // .Map(dst => dst.ExternalId,
        //     src => ;
    }
}
