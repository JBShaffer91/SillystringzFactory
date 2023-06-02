using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.EngineerMachines = new HashSet<EngineerMachine>();
      this.Name = "";
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<EngineerMachine> EngineerMachines { get; set; }
  }
}