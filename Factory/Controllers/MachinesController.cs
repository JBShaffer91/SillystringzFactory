using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
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
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine? thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      if (thisMachine == null)
      {
        return NotFound();
      }
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      Machine? thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      if (thisMachine == null)
      {
        return NotFound();
      }
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
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
