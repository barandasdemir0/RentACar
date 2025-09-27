using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.AboutCommands
{
    public class UpdateAboutCommand
    {
        public int AboutID { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
        public string? AboutImageUrl { get; set; }
    }
}
