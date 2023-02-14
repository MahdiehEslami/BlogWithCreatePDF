using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.EndPoint.BlazorShared.Components
{
    public partial class ErrorMessage
    {
        [Parameter]
        public string Message { get; set; }
    }
}
