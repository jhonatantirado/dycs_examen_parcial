using System.Collections.Generic;

namespace DepotSystem.API.Application.Response
{
    public class ApiErrorDto
    {
        public List<ErrorDto> Errors { get; set; } = new List<ErrorDto>();
    }
}
