namespace Beblue.Domain.Discs.Commands
{
    public class CreateDiscCommand: BaseDiscCommand
    {
        public CreateDiscCommand(string genre ,string name)
        {
            this.Name = name;
            this.Genre = genre;
        }
    }
}
