using System.Collections.Generic;

namespace Utilities.APILinks
{
    public class LinkResourceBase
    {
        public LinkResourceBase()
        {
        }
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
