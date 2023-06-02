using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new MultiSelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, List<int> MachineId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      if (MachineId.Count != 0)
      {
        foreach (int id in MachineId)
        {
          _db.EngineerMachines.Add(new EngineerMachine() { MachineId = id, EngineerId = engineer.EngineerId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.EngineerMachines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new MultiSelectList(_db.Machines, "MachineId", "Name");
      if (thisEngineer == null)
      {
        return NotFound();
      }
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer, List<int> MachineId)
    {
      if (MachineId.Count != 0)
      {
        foreach (int id in MachineId)
        {
          _db.EngineerMachines.Add(new EngineerMachine() { MachineId = id, EngineerId = engineer.EngineerId });
        }
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      if (thisEngineer == null)
      {
        return NotFound();
      }
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      if (thisEngineer == null)
      {
        return NotFound();
      }
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
