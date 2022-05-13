using SicopataPedidos.Core.Base.BaseDto;
using System.Text.Json.Serialization;

namespace SicopataPedidos.Bl.Dtos
{
    public class UserDto: BaseDto
    {
        [JsonIgnore]
        public override bool Deleted { get => base.Deleted; set => base.Deleted = value; }

    }
}
