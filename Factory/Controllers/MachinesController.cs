using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int[] EngineerId)
    {
      _db.Machines.Add(machine);
      if (EngineerId.Length != 0)
      {
        foreach (int id in EngineerId)
        {
          _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = id, MachineId = machine.MachineId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine? thisMachine = _db.Machines
                                .Include(m => m.EngineerMachines)
                                .ThenInclude(em => em.Engineer)
                                .FirstOrDefault(machine => machine.MachineId == id);
      if (thisMachine == null)
      {
        return NotFound();
      }
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      if (thisMachine == null)
      {
        return NotFound();
      }
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int[] EngineerId)
    {
      var thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == machine.MachineId);
      if (thisMachine == null)
      {
        return NotFound();
      }

      if (EngineerId.Length != 0)
      {
        _db.EngineerMachines.RemoveRange(_db.EngineerMachines.Where(em => em.MachineId == machine.MachineId));
        foreach (int id in EngineerId)
        {
          _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = id, MachineId = machine.MachineId });
        }
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine? thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      if (thisMachine == null)
      {
        return NotFound();
      }
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine? thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      if (thisMachine == null)
      {
        return NotFound();
      }
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
