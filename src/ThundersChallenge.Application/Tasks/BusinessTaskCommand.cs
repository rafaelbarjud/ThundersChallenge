

namespace ThundersChallenge.Application.Tasks;

public  class BusinessTaskCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid Responsible { get; set; }
}
