using BuisnessLogic.BindingModels;
using BuisnessLogic.StorageInterfaces;
using BuisnessLogic.ViewModels;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Implements
{
    public class RepairStorage : IRepairStorage
    {
            public List<RepairViewModel> GetFullList()
            {
                using var context = new StoDatabase();
                return context.Repairs
                 .Include(rec => rec.RepairWorks)
                 .ThenInclude(rec => rec.Work)
                 .Include(x => x.Client)
                 .Include(x => x.Employee)
                .Select(CreateModel)
                .ToList();
            }
            public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using var context = new StoDatabase();
                return context.Repairs.Include(rec => rec.RepairWorks)
                 .ThenInclude(rec => rec.Work)
                 .Include(x => x.Client)
                 .Include(x => x.Employee).Where(rec => rec.ClientId == model.ClientId)
                .Select(CreateModel)

                .ToList();
            }
            public List<RepairViewModel> GetFilteredListRepair(RepairBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using var context = new StoDatabase();
                return context.Repairs.Include(rec => rec.RepairWorks)
                 .ThenInclude(rec => rec.Work)
                 .Include(x => x.Client)
                 .Include(x => x.Employee).Where(rec => rec.EmployeeId == model.EmployeeId)
                .Select(CreateModel)

                .ToList();
            }
            public List<RepairViewModel> GetFilteredListDate(RepairBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using var context = new StoDatabase();
                return context.Repairs.Include(rec => rec.RepairWorks)
                 .ThenInclude(rec => rec.Work)
                 .Include(x => x.Client)
                 .Include(x => x.Employee).Where(rec => rec.Id.Equals(model.Id) || rec.DateStart >= model.DateFrom && rec.DateStart <= model.DateTo)
                .Select(CreateModel)

                .ToList();
            }
            public RepairViewModel GetElement(RepairBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using var context = new StoDatabase();
                var repair = context.Repairs
                    .Include(rec => rec.RepairWorks)
                 .ThenInclude(rec => rec.Work)
                 .Include(x => x.Client)
                 .Include(x => x.Employee)
                .FirstOrDefault(rec => rec.Id == model.Id)
                ;
                if (repair == null)
                {
                    return null;
                }
                return CreateModel(repair);
            }
            public void Insert(RepairBindingModel model)
            {
                using var context = new StoDatabase();
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    CreateModel(model, new Repair(), context);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    transaction.Rollback();
                    throw;
                }
            }
            public void Update(RepairBindingModel model)
            {
                using var context = new StoDatabase();
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    var element = context.Repairs.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    CreateModel(model, element, context);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    transaction.Rollback();
                    throw;
                }
            }
            public void Delete(RepairBindingModel model)
            {
                using var context = new StoDatabase();
                Repair element = context.Repairs.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element != null)
                {
                    context.Repairs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            private static Repair CreateModel(RepairBindingModel model, Repair repair,
           StoDatabase context)
            {
                repair.Name = model.Name;
                repair.WorkId = model.WorkId;
                repair.EmployeeId = model.EmployeeId;
                repair.ClientId = model.ClientId;
                repair.Status = model.Status;
                repair.Sum = model.Sum;
                repair.DateStart = model.DateStart;
                repair.DateEnd = model.DateEnd;
                repair.Sum = model.Sum;
                if (repair.Id == 0)
                {
                    context.Repairs.Add(repair);
                    context.SaveChanges();
                }
                if (model.Id != 0)
                {
                    var repairServices = context.RepairWorks.Where(rec =>
                   rec.RepairId == model.Id).ToList();
                    // удалили те, которых нет в модели
                    context.RepairWorks.RemoveRange(repairServices.Where(rec =>
                   !model.repairWorks.ContainsKey((int)rec.RepairId)).ToList());
                    context.SaveChanges();
                    context.SaveChanges();
                }
                // добавили новые
                foreach (var pc in model.repairWorks)
                {
                    context.RepairWorks.Add(new RepairWork
                    {
                        RepairId = repair.Id,
                        WorkId = pc.Key,
                    });
                    var temp = context.RepairWorks;
                    context.SaveChanges();
                }
                return repair;
            }
            private static RepairViewModel CreateModel(Repair repair)
            {
                return new RepairViewModel
                {
                    Id = repair.Id,
                    ClientId = repair.ClientId,
                    DateEnd = repair.DateEnd,
                    DateStart = repair.DateStart,
                    EmployeeId = repair.EmployeeId,
                    Name = repair.Name,
                    Status = repair.Status,
                    Sum = repair.Sum,
                    repairWorks = repair.RepairWorks
                .ToDictionary(recPC => recPC.WorkId,
                recPC => recPC.Work?.WorkName)
                };
            }
        }
}
