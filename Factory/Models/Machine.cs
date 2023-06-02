using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.EngineerMachines = new HashSet<EngineerMachine>();
      this.Name = "";
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<EngineerMachine> EngineerMachines { get; set; }
  }
}