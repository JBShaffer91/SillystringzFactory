using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Engineers = new HashSet<Engineer>();
      this.Name = "";
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Engineer> Engineers { get; set; }
  }
}