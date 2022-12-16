using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IReleaseService
    {
        Release AddRelease(Release release);

        ICollection<Release> List();
    }
}
